using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using System.IO.Ports;
using System.IO;
using System.Threading;
using ScottPlot.Plottable;
using System.Diagnostics;

namespace Software_EKG_STM32
{
    public partial class Form1 : Form
    {
        // Definisi kode lead primer
        public enum ECGPrimaryLead
        {
            R_F  = 0,
            L_F  = 1,
            C1_F = 2,
            C2_F = 3,
            C3_F = 4,
            C4_F = 5,
            C5_F = 6,
            C6_F = 7
        }

        // Definisi kode lead
        public enum ECGLead
        {
            LeadI   = 0,
            LeadII  = 1,
            LeadIII = 2,
            LeadAVR = 3,
            LeadAVL = 4,
            LeadAVF = 5,
            LeadV1  = 6,
            LeadV2  = 7,
            LeadV3  = 8,
            LeadV4  = 9,
            LeadV5  = 10,
            LeadV6  = 11
        }

        // Direktori rekaman EKG
        // (folder aplikasi)\bin\Rekaman EKG
        string ECGRecordPath = @"..\..\Rekaman EKG\";

        SerialPort serial;      // Objek SerialPort
        byte[] usbTxData = new byte[5];
        byte[] usbRxData = new byte[320];
        Int16[] ecgRawDataBuffer = new Int16[160];  // Buffer untuk EKG 40 ms
        bool dataReceived = false;
        bool serialPendingClose = false;
        bool recordStart = false;

        double samplingFreqBase = 500.0;

        // Array pulsa kalibrasi
        double[][] ECGCalPulse =
        {
            new double[200],    // Lead I
            new double[200],    // Lead II
            new double[200],    // Lead III
            new double[200],    // Lead aVR
            new double[200],    // Lead aVL
            new double[200],    // Lead aVF
            new double[200],    // Lead V1
            new double[200],    // Lead V2
            new double[200],    // Lead V3
            new double[200],    // Lead V4
            new double[200],    // Lead V5
            new double[200]     // Lead V6
        };

        // Faktor gain
        double[] GainFactor = { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 }; // I, II, III, aVR, ... V6

        // Offset dasar
        double[] OffsetBase = { 14.0, 11.5, 9.0, 6.5, 4.0, 1.5, 14.0, 11.5, 9.0, 6.5, 4.0, 1.5 };

        // Teks header
        ScottPlot.Plottable.Text PlotHeaderInstituteName;
        ScottPlot.Plottable.Text PlotHeaderPatientName;
        ScottPlot.Plottable.Text PlotHeaderBirthDate;
        ScottPlot.Plottable.Text PlotHeaderSex;
        ScottPlot.Plottable.Text PlotHeaderPatientID;
        ScottPlot.Plottable.Text PlotHeaderNotes;
        ScottPlot.Plottable.Text PlotFooterOperator;
        ScottPlot.Plottable.Text PlotFooterDateTime;
        ScottPlot.Plottable.Text PlotStatusLPF;
        ScottPlot.Plottable.Text PlotStatusHPF;
        ScottPlot.Plottable.Text PlotStatusPLF;
        ScottPlot.Plottable.Text PlotStatusTimebase;
        ScottPlot.Plottable.Text PlotStatusGain;

        // Gambar logo Unila
        ScottPlot.Plottable.Image PlotLogoUnila;

        // Plot
        SignalPlot[] PlotECGCalPulse = new SignalPlot[12];
        SignalPlot[] PlotECGLead = new SignalPlot[12];

        // Buffer lead
        int BlockNum = 0;
        double K = 0.0;
        double[][] LeadDataBuffer =
        {
            new double[20], // Lead I
            new double[20], // Lead II
            new double[20], // Lead III
            new double[20], // Lead aVR
            new double[20], // Lead aVL
            new double[20], // Lead aVF
            new double[20], // Lead V1
            new double[20], // Lead V2
            new double[20], // Lead V3
            new double[20], // Lead V4
            new double[20], // Lead V5
            new double[20]  // Lead V6
        };

        // Buffer plot
        double[][] PlotECGBuffer =
        {
            new double[2500],   // Lead I
            new double[2500],   // Lead II
            new double[2500],   // Lead III
            new double[2500],   // Lead aVR
            new double[2500],   // Lead aVL
            new double[2500],   // Lead aVF
            new double[2500],   // Lead V1
            new double[2500],   // Lead V2
            new double[2500],   // Lead V3
            new double[2500],   // Lead V4
            new double[2500],   // Lead V5
            new double[2500]    // Lead V6
        };

        StreamWriter csvWrite;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event ketika Form dimuat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Inisialisasi program
            Directory.CreateDirectory(ECGRecordPath);
            timerUpdateTime.Start();
            serial = new SerialPort();
            serial.ReadBufferSize = 640;
            serial.WriteBufferSize = 320;
            btnUSBConnect.BackColor = Color.LightCoral;
            cbFilterLP.SelectedIndex = cbFilterLP.Items.IndexOf("150 Hz");
            cbFilterHP.SelectedIndex = cbFilterHP.Items.IndexOf("0,25 Hz");
            cbTimebaseECG.SelectedIndex = cbTimebaseECG.Items.IndexOf("25 mm/s");
            cbGainECG.SelectedIndex = cbGainECG.Items.IndexOf("10 mm/mV");
            if (chbFilterHPOn.Checked == false)
            {
                cbFilterHP.Enabled = false;
            }
            serial.ReceivedBytesThreshold = 320;
            serial.ReadTimeout = 1000;

            // Identifikasi versi DEBUG atau RELEASE
            // Tujuannya bisa untuk enable atau disable fitur tertentu
#if DEBUG
            krLabelBuildVer.Text += Environment.NewLine;
            krLabelBuildVer.Text += @"Build DEBUG -- Februari 2022";
            plotRealtimeEKG.Configuration.DoubleClickBenchmark = true;
            this.Text += @" --Versi DEBUG, untuk development--";
#else
            plotRealtimeEKG.Configuration.DoubleClickBenchmark = false;
#endif  
            // Inisialisasi grafik realtime
            plotRealtimeEKG.Configuration.LockHorizontalAxis = true;    
            plotRealtimeEKG.Configuration.LockVerticalAxis = true;
            plotRealtimeEKG.Configuration.Zoom = false;
            plotRealtimeEKG.Configuration.Quality = ScottPlot.Control.QualityMode.Low;
            plotRealtimeEKG.Configuration.DpiStretch = false;
            plotRealtimeEKG.Plot.Frameless(true);
            plotRealtimeEKG.Plot.Style(figureBackground:Color.LightSkyBlue, dataBackground: Color.WhiteSmoke);
            plotRealtimeEKG.Plot.XAxis.MajorGrid(enable: true, color: Color.Salmon, lineWidth: 2.0f, lineStyle: ScottPlot.LineStyle.Solid);
            plotRealtimeEKG.Plot.XAxis.MinorGrid(enable: true, color: Color.LightSalmon, lineWidth: 0.1f, lineStyle: ScottPlot.LineStyle.Solid);
            plotRealtimeEKG.Plot.YAxis.MajorGrid(enable: true, color: Color.Salmon, lineWidth: 2.0f, lineStyle: ScottPlot.LineStyle.Solid);
            plotRealtimeEKG.Plot.YAxis.MinorGrid(enable: true, color: Color.LightSalmon, lineWidth: 0.5f, lineStyle: ScottPlot.LineStyle.Solid);
            plotRealtimeEKG.Plot.SetAxisLimits(xMin: -1.2, xMax: 11.2, yMin: -1.0, yMax: 18.0, xAxisIndex: 0, yAxisIndex: 0);
            plotRealtimeEKG.Plot.XAxis.ManualTickSpacing(0.2);
            plotRealtimeEKG.Plot.YAxis.ManualTickSpacing(0.5);
            plotRealtimeEKG.Plot.XAxis.Ticks(false);
            plotRealtimeEKG.Plot.YAxis.Ticks(false);
            plotRealtimeEKG.Plot.Width = 2245;
            plotRealtimeEKG.Plot.Height = 1587;
            // Teks status pengaturan dan header
            Bitmap logoUnila = new Bitmap(Properties.Resources.logo_unila);
            PlotLogoUnila = plotRealtimeEKG.Plot.AddImage(logoUnila, -1.1, 17.8);
            PlotLogoUnila.Scale = 0.065f;
            PlotHeaderInstituteName = plotRealtimeEKG.Plot.AddText("REKAMAN ELEKTROKARDIOGRAFI (EKG)\n" +
                                                       "Jurusan Fisika Fakultas MIPA\n" +
                                                       "Universitas Lampung", -0.45, 17.8, 19.0f, Color.Black);
            PlotHeaderInstituteName.Font.Name = "Agency FB";
            PlotHeaderInstituteName.FontBold = true;
            PlotStatusLPF = plotRealtimeEKG.Plot.AddText("", 7.0, 0.0, 16.0f, Color.Black);
            PlotStatusLPF.Label = "LPF 150 Hz";
            PlotStatusHPF = plotRealtimeEKG.Plot.AddText("", 8.0, 0.0, 16.0f, Color.Black);
            PlotStatusHPF.Label = "HPF mati";
            PlotStatusPLF = plotRealtimeEKG.Plot.AddText("", 9.0, 0.0, 16.0f, Color.Black);
            PlotStatusPLF.Label = "Reduksi 50 Hz mati";
            PlotStatusTimebase = plotRealtimeEKG.Plot.AddText("25 mm/s", 6.0, 0.0, 16.0f, Color.Black);
            PlotStatusGain = plotRealtimeEKG.Plot.AddText("10 mm/mV", 5.0, 0.0, 16.0f, Color.Black);
            PlotFooterOperator = plotRealtimeEKG.Plot.AddText("Direkam oleh:", -1.0, 0.0, 16.0f, Color.Black);
            PlotFooterDateTime = plotRealtimeEKG.Plot.AddText(DateTime.Now.ToString(), 3.0, 0.0, 16.0f, Color.Black);
            PlotHeaderPatientName = plotRealtimeEKG.Plot.AddText("Nama:", 2.4, 17.8, 16.0f, Color.Black);
            PlotHeaderBirthDate = plotRealtimeEKG.Plot.AddText( "Tgl. Lahir:", 2.4, 17.3, 16.0f, Color.Black);
            PlotHeaderSex = plotRealtimeEKG.Plot.AddText("Jenis Kelamin:", 2.4, 16.8, 16.0f, Color.Black);
            PlotHeaderPatientID = plotRealtimeEKG.Plot.AddText("ID: " + tbRecord_ID.Text, 2.4, 16.3, 16.0f, Color.Black);
            PlotHeaderNotes = plotRealtimeEKG.Plot.AddText("CATATAN:" + Environment.NewLine, 5.5, 17.8, 14.0f, Color.Black);

            // Label lead
            var plotRealtimeEKG_LabelLeadI = plotRealtimeEKG.Plot.AddText("Lead I", -1.0, 15.0, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadI.FontBold = true;
            plotRealtimeEKG_LabelLeadI.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadI.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadII = plotRealtimeEKG.Plot.AddText("Lead II", -1.0, 12.5, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadII.FontBold = true;
            plotRealtimeEKG_LabelLeadII.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadII.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadIII = plotRealtimeEKG.Plot.AddText("Lead III", -1.0, 10.0, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadIII.FontBold = true;
            plotRealtimeEKG_LabelLeadIII.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadIII.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadAVR = plotRealtimeEKG.Plot.AddText("Lead aVR", -1.0, 7.5, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadAVR.FontBold = true;
            plotRealtimeEKG_LabelLeadAVR.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadAVR.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadAVL = plotRealtimeEKG.Plot.AddText("Lead aVL", -1.0, 5.0, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadAVL.FontBold = true;
            plotRealtimeEKG_LabelLeadAVL.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadAVL.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadAVF = plotRealtimeEKG.Plot.AddText("Lead aVF", -1.0, 2.5, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadAVF.FontBold = true;
            plotRealtimeEKG_LabelLeadAVF.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadAVF.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadV1 = plotRealtimeEKG.Plot.AddText("Lead V1", 5.0, 15.0, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadV1.FontBold = true;
            plotRealtimeEKG_LabelLeadV1.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadV1.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadV2 = plotRealtimeEKG.Plot.AddText("Lead V2", 5.0, 12.5, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadV2.FontBold = true;
            plotRealtimeEKG_LabelLeadV2.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadV2.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadV3 = plotRealtimeEKG.Plot.AddText("Lead V3", 5.0, 10.0, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadV3.FontBold = true;
            plotRealtimeEKG_LabelLeadV3.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadV3.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadV4 = plotRealtimeEKG.Plot.AddText("Lead V4", 5.0, 7.5, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadV4.FontBold = true;
            plotRealtimeEKG_LabelLeadV4.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadV4.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadV5 = plotRealtimeEKG.Plot.AddText("Lead V5", 5.0, 5.0, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadV5.FontBold = true;
            plotRealtimeEKG_LabelLeadV5.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadV5.BackgroundColor = Color.Salmon;
            var plotRealtimeEKG_LabelLeadV6 = plotRealtimeEKG.Plot.AddText("Lead V6", 5.0, 2.5, 12.0f, Color.Black);
            plotRealtimeEKG_LabelLeadV6.FontBold = true;
            plotRealtimeEKG_LabelLeadV6.BackgroundFill = true;
            plotRealtimeEKG_LabelLeadV6.BackgroundColor = Color.Salmon;

            // Pulsa kalibrasi
            for(int ii=0; ii<12; ii++)
            {
                for(int ij=59; ij<140;ij++)
                {
                    ECGCalPulse[ii][ij] = 1.0;
                }
            }

            // Tampilan pulsa kalibrasi dan gain
            for(int ii=0; ii<12; ii++)
            {
                PlotECGCalPulse[ii] = plotRealtimeEKG.Plot.AddSignal(ECGCalPulse[ii], samplingFreqBase, Color.Black);
                PlotECGCalPulse[ii].LineWidth = 2.0;
                if(ii < 6)
                {
                    PlotECGCalPulse[ii].OffsetX = -0.5;
                }
                else
                {
                    PlotECGCalPulse[ii].OffsetX = 5.5;
                }
                PlotECGCalPulse[ii].OffsetY = OffsetBase[ii] - 0.5;
            }
            
            // Inisialisasi plot EKG realtime
            for(int ii=0; ii<12; ii++)
            {
                PlotECGLead[ii] = plotRealtimeEKG.Plot.AddSignal(PlotECGBuffer[ii], samplingFreqBase, Color.Black);
                PlotECGLead[ii].LineWidth = 2.0;
                if (ii < 6)
                {
                    PlotECGLead[ii].OffsetX = 0.0;
                }
                else
                {
                    PlotECGLead[ii].OffsetX = 6.0;
                }
                PlotECGLead[ii].OffsetY = OffsetBase[ii];
                PlotECGLead[ii].UseParallel = true;
            }

            // Update grafik
            plotRealtimeEKG.Render();
        }

        /// <summary>
        /// Event ketika Form tertutup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serial.DtrEnable = false;
            serial.Close();
            serial.DataReceived -= serial_DataReceived;
            timerUpdateTime.Stop();
            Application.Exit();
        }

        /// <summary>
        /// Event ketika memilih COM Port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach(string p in port)
            {
                comboBox1.Items.Add(p);
            }
        }

        /// <summary>
        /// Event ketika user mengklik tombol Sambung/Putuskan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUSBConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serial.IsOpen)
                {
                    // Buka komunikasi serial
                    serial.PortName = comboBox1.SelectedItem.ToString();
                    serial.DataReceived += serial_DataReceived;
                    serial.Open();
                    // Kirim pengaturan awal
                    // 1. Low-Pass Filter
                    usbTxData[0] = Convert.ToByte('L'); ;
                    switch (cbFilterLP.SelectedItem.ToString())
                    {
                        case "40 Hz":
                            usbTxData[1] = 0;
                            break;
                        case "75 Hz":
                            usbTxData[1] = 1;
                            break;
                        case "150 Hz":
                            usbTxData[1] = 2;
                            break;
                    }
                    usbTxData[4] = 1;
                    serial.Write(usbTxData, 0, 5);
                    Thread.Sleep(100);
                    // 2. High-Pass Filter
                    usbTxData[0] = Convert.ToByte('H'); ;
                    if (chbFilterHPOn.CheckState == CheckState.Unchecked)
                    {
                        usbTxData[1] = 0;
                    }
                    else
                    {
                        switch (cbFilterHP.SelectedItem.ToString())
                        {
                            case "0,25 Hz":
                                usbTxData[1] = 1;
                                break;
                            case "0,5 Hz":
                                usbTxData[1] = 2;
                                break;
                        }
                    }
                    usbTxData[4] = 1;
                    serial.Write(usbTxData, 0, 5);
                    Thread.Sleep(100);
                    // 3. Powerline Filter
                    usbTxData[0] = Convert.ToByte('P'); ;
                    switch(chbFilter50Hz.CheckState)
                    {
                        case CheckState.Unchecked:
                            usbTxData[1] = 0;
                            break;
                        case CheckState.Checked:
                            usbTxData[1] = 1;
                            break;
                    }
                    usbTxData[4] = 1;
                    serial.Write(usbTxData, 0, 5);
                    Thread.Sleep(100);
                    for (int ii = 0; ii < 2500; ii++)
                    {
                        for (int ij = 0; ij < 12; ij++)
                        {
                            PlotECGBuffer[ij][ii] = 0.0;
                        }
                    }
                    BlockNum = 0;
                    for (int ii = 0; ii < 12; ii++)
                    {
                        Array.Clear(PlotECGBuffer[ii], 0, PlotECGBuffer[ii].Length);
                    }
                    plotRealtimeEKG.Render();
                    btnUSBConnect.BackColor = Color.LightGreen;
                    lblECGDeviceStatus.Text = "Aktif";
                    lblECGDeviceStatus.BackColor = Color.LightGreen;
                    serial.DtrEnable = true;
                    timerRenderRealtime.Start();
                }
                else
                {
                    // Tutup komunikasi serial
                    serialPendingClose = true;
                    serial.DtrEnable = false;
                    Thread.Sleep(serial.ReadTimeout);
                    serial.Close();
                    timerRenderRealtime.Stop();
                    serial.DataReceived -= serial_DataReceived;
                    btnUSBConnect.BackColor = Color.LightCoral;
                    lblECGDeviceStatus.Text = "Nonaktif";
                    lblECGDeviceStatus.BackColor = Color.IndianRed;
                    serialPendingClose = false;
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("COM Port tidak boleh kosong!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nonaktifkan/aktifkan HPF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbFilterHPOn_CheckedChanged(object sender, EventArgs e)
        {
            // Cek state filter HPF
            switch (chbFilterHPOn.CheckState)
            {
                case CheckState.Unchecked:
                    cbFilterHP.Enabled = false;
                    usbTxData[0] = Convert.ToByte('H'); ;
                    usbTxData[1] = 0;
                    usbTxData[4] = 1;
                    PlotStatusHPF.Label = "HPF mati";
                    break;
                case CheckState.Checked:
                    cbFilterHP.Enabled = true;
                    usbTxData[0] = Convert.ToByte('H');
                    if (cbFilterHP.SelectedItem.ToString() == "0,25 Hz")
                    {
                        usbTxData[1] = 1;
                        PlotStatusHPF.Label = "HPF 0,25 Hz";
                    }
                    if (cbFilterHP.SelectedItem.ToString() == "0,5 Hz")
                    {
                        usbTxData[1] = 2;
                        PlotStatusHPF.Label = "HPF 0,5 Hz";
                    }
                    usbTxData[4] = 1;
                    break;
            }
            plotRealtimeEKG.Render();
            if (serial.IsOpen)
            {
                serial.Write(usbTxData, 0, 5);
            }
        }

        /// <summary>
        /// Pengaturan filter reduksi noise 50 Hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbFilter50Hz_CheckedChanged(object sender, EventArgs e)
        {
            switch (chbFilter50Hz.CheckState)
            {
                case CheckState.Unchecked:
                    usbTxData[0] = Convert.ToByte('P');
                    usbTxData[1] = 0;
                    usbTxData[4] = 1;
                    PlotStatusPLF.Label = "Reduksi 50 Hz mati";
                    break;
                case CheckState.Checked:
                    usbTxData[0] = Convert.ToByte('P');
                    usbTxData[1] = 1;
                    usbTxData[4] = 1;
                    PlotStatusPLF.Label = "Reduksi 50 Hz hidup";
                    break;
            }
            plotRealtimeEKG.Render();
            if (serial.IsOpen)
            {
                serial.Write(usbTxData, 0, 5);
            }
        }

        /// <summary>
        /// Pengaturan low-pass filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterLP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbFilterLP.SelectedItem.ToString())
            {
                case "40 Hz":
                    usbTxData[0] = Convert.ToByte('L');
                    usbTxData[1] = 0;
                    usbTxData[4] = 1;
                    PlotStatusLPF.Label = "LPF 40 Hz";
                    break;
                case "75 Hz":
                    usbTxData[0] = Convert.ToByte('L');
                    usbTxData[1] = 1;
                    usbTxData[4] = 1;
                    PlotStatusLPF.Label = "LPF 75 Hz";
                    break;
                case "150 Hz":
                    usbTxData[0] = Convert.ToByte('L');
                    usbTxData[1] = 2;
                    usbTxData[4] = 1;
                    PlotStatusLPF.Label = "LPF 150 Hz";
                    break;
            }
            plotRealtimeEKG.Render();
            if (serial.IsOpen)
            {
                serial.Write(usbTxData, 0, 5);
            }
        }

        /// <summary>
        /// Pengaturan high-pass filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterHP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbFilterHP.SelectedItem.ToString())
            {
                case "0,25 Hz":
                    usbTxData[0] = Convert.ToByte('H');
                    usbTxData[1] = 1;
                    usbTxData[4] = 1;
                    PlotStatusHPF.Label = "HPF 0,25 Hz";
                    break;
                case "0,5 Hz":
                    usbTxData[0] = Convert.ToByte('L');
                    usbTxData[1] = 2;
                    usbTxData[4] = 1;
                    PlotStatusHPF.Label = "HPF 0,5 Hz";
                    break;
            }
            plotRealtimeEKG.Render();
            if (serial.IsOpen)
            {
                serial.Write(usbTxData, 0, 5);
            }
        }

        /// <summary>
        /// Event ketika PC menerima data dari EKG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int k = 0;

            if(!serialPendingClose)
            {
                // Sebenarnya secara logis lebih baik menggunakan Read() saja
                // Tetapi justru datanya menjadi kacau...
                do
                {
                    usbRxData[k] = Convert.ToByte(serial.ReadByte());
                    if (serialPendingClose) break;
                    k++;
                } while (k < usbRxData.Length);

                Buffer.BlockCopy(usbRxData, 0, ecgRawDataBuffer, 0, usbRxData.Length);
                serial.DiscardInBuffer();

                if (!workerRender.IsBusy)
                {
                    workerRender.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// Event timer untuk merender plot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRenderRealtime_Tick(object sender, EventArgs e)
        {
            timerRenderRealtime.Stop();
            if(dataReceived)
            {
                plotRealtimeEKG.Render();
                dataReceived = false;
            }
            timerRenderRealtime.Start();
        }

        /// <summary>
        /// Thread BackgroundWorker untuk memproses data EKG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workerRender_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            for (int i = 0; i < 20; i++)
            {
                K = 0.333 * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.R_F] + ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.L_F]);

                // Ekstrak lead I
                PlotECGBuffer[(int)ECGLead.LeadI][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadI]
                                                      * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.L_F] - ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.R_F])
                                                      * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadI][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadI][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadI][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadI][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead II
                PlotECGBuffer[(int)ECGLead.LeadII][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadII]
                                                       * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.R_F])
                                                       * -0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadII][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadII][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadII][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadII][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead III
                PlotECGBuffer[(int)ECGLead.LeadIII][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadIII]
                                                        * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.L_F])
                                                        * -0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadIII][(20 * BlockNum) + i] > 2.5) LeadDataBuffer[(int)ECGLead.LeadIII][i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadIII][(20 * BlockNum) + i] < -2.5) LeadDataBuffer[(int)ECGLead.LeadIII][i] = -2.5;

                // Ekstrak lead aVR
                PlotECGBuffer[(int)ECGLead.LeadAVR][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadAVR]
                                                        * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.R_F])
                                                        - 0.5 * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.L_F]))
                                                        * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadAVR][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadAVR][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadAVR][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadAVR][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead aVL
                PlotECGBuffer[(int)ECGLead.LeadAVL][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadAVL]
                                                        * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.L_F])
                                                        - 0.5 * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.R_F]))
                                                        * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadAVL][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadAVL][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadAVL][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadAVL][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead aVF
                PlotECGBuffer[(int)ECGLead.LeadAVF][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadAVF]
                                                        * 0.5 * Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.R_F] + ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.L_F])
                                                        * -0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadAVF][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadAVF][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadAVF][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadAVF][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead V1
                PlotECGBuffer[(int)ECGLead.LeadV1][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadV1]
                                                       * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.C1_F]) - K) * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadV1][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadV1][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadV1][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadV1][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead V2
                PlotECGBuffer[(int)ECGLead.LeadV2][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadV2]
                                                       * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.C2_F]) - K) * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadV2][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadV2][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadV2][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadV2][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead V3
                PlotECGBuffer[(int)ECGLead.LeadV3][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadV3]
                                                       * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.C3_F]) - K) * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadV3][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadV3][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadV3][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadV3][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead V4
                PlotECGBuffer[(int)ECGLead.LeadV4][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadV4]
                                                       * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.C4_F]) - K) * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadV4][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadV4][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadV4][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadV4][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead V5
                PlotECGBuffer[(int)ECGLead.LeadV5][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadV5]
                                                       * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.C5_F]) - K) * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadV5][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadV5][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadV5][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadV5][(20 * BlockNum) + i] = -2.5;

                // Ekstrak lead V6
                PlotECGBuffer[(int)ECGLead.LeadV6][(20 * BlockNum) + i] = GainFactor[(int)ECGLead.LeadV6]
                                                       * (Convert.ToDouble(ecgRawDataBuffer[(8 * i) + (int)ECGPrimaryLead.C6_F]) - K) * 0.000794728597;
                if (PlotECGBuffer[(int)ECGLead.LeadV6][(20 * BlockNum) + i] > 2.5) PlotECGBuffer[(int)ECGLead.LeadV6][(20 * BlockNum) + i] = 2.5;
                if (PlotECGBuffer[(int)ECGLead.LeadV6][(20 * BlockNum) + i] < -2.5) PlotECGBuffer[(int)ECGLead.LeadV6][(20 * BlockNum) + i] = -2.5;
            }

            // Jika sudah selesai merekam (BlockNum == 124)
            if ((BlockNum == 124) && recordStart)
            {
                // Simpan rekaman dalam format CSV
                // Untuk bisa dibuka di MATLAB, Excel, dll
                csvWrite = new StreamWriter(ECGRecordPath + tbRecord_ID.Text + "_" + tbRecord_Name.Text + ".csv", false, Encoding.UTF8);
                using (csvWrite)
                {
                    // Tulis header identifikasi
                    csvWrite.WriteLine("ID,Name,BirthDate,Sex,DateTime");
                    csvWrite.WriteLine(tbRecord_ID.Text + "," + tbRecord_Name.Text + "," + dtRecord_BirthDate.Text + "," + cbRecord_Sex.Text + "," + DateTime.Now.ToString());
                    csvWrite.WriteLine(Environment.NewLine);
                    // Tulis data EKG
                    csvWrite.WriteLine("I,II,V1,V2,V3,V4,V5,V6");   // Lead III dan augmented bisa diekstrak dari lead I dan II
                    for(int i=0; i<PlotECGBuffer[(int)ECGLead.LeadI].Length; i++)
                    {
                        // Simpan dalam presisi 7 digit belakang koma
                        csvWrite.WriteLine("{0:F7},{1:F7},{2:F7},{3:F7},{4:F7},{5:F7},{6:F7},{7:F7}", PlotECGBuffer[(int)ECGLead.LeadI][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadII][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadV1][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadV2][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadV3][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadV4][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadV5][i],
                                                                                                      PlotECGBuffer[(int)ECGLead.LeadV6][i]);
                    }
                }
                // Simpan rekaman EKG dalam format PNG
                plotRealtimeEKG.Plot.SaveFig(ECGRecordPath + tbRecord_ID.Text + "_" + tbRecord_Name.Text + ".png", 1754, 1240, false, 1);

                MessageBox.Show("Rekaman EKG telah dibuat.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblECGDeviceStatus.Text = "Aktif";
                lblECGDeviceStatus.BackColor = Color.LightGreen;
                recordStart = false;
            }
        }

        /// <summary>
        /// Event ketika workerRender selesai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workerRender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BlockNum = (BlockNum + 1) % 125;
            dataReceived = true;
        }

        /// <summary>
        /// Event ketika user telah memilih gain EKG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbGainECG_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbGainECG.SelectedItem.ToString())
            {
                case "5 mm/mV":
                    for (int i = 59; i < 140; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            ECGCalPulse[j][i] = 0.5;
                            GainFactor[j] = 0.5;
                        }
                    }
                    PlotStatusGain.Label = "5 mm/mV";
                    break;
                case "10 mm/mV":
                    for (int i = 59; i < 140; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            ECGCalPulse[j][i] = 1.0;
                            GainFactor[j] = 1.0;
                        }
                    }
                    PlotStatusGain.Label = "10 mm/mV";
                    break;
                case "20 mm/mV":
                    for (int i = 59; i < 140; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            ECGCalPulse[j][i] = 2.0;
                            GainFactor[j] = 2.0;
                        }
                    }
                    PlotStatusGain.Label = "20 mm/mV";
                    break;
            }
            plotRealtimeEKG.Render();
        }

        /// <summary>
        /// Event ketika user telah memilih timebase EKG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTimebaseECG_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch(cbTimebaseECG.SelectedItem.ToString())
            {
                case "25 mm/s":
                    for(int i=0; i<12; i++)
                    {
                        PlotECGLead[i].SamplePeriod = 0.002;
                        PlotECGLead[i].MaxRenderIndex = 2499;
                        PlotStatusTimebase.Label = "25 mm/s";
                    }
                    break;
                case "50 mm/s":
                    for (int i = 0; i < 12; i++)
                    {
                        PlotECGLead[i].SamplePeriod = 0.004;
                        PlotECGLead[i].MaxRenderIndex = 1249;
                        PlotStatusTimebase.Label = "50 mm/s";
                    }
                    break;
            }
            plotRealtimeEKG.Render();
        }

        /// <summary>
        /// Pengaturan offset vertikal EKG (untuk menghindari overlap, dll...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numOffsetLeadI_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadI].OffsetY = OffsetBase[(int)ECGLead.LeadI] + Convert.ToDouble(numOffsetLeadI.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadII_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadII].OffsetY = OffsetBase[(int)ECGLead.LeadII] + Convert.ToDouble(numOffsetLeadII.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadIII_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadIII].OffsetY = OffsetBase[(int)ECGLead.LeadIII] + Convert.ToDouble(numOffsetLeadIII.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadAVR_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadAVR].OffsetY = OffsetBase[(int)ECGLead.LeadAVR] + Convert.ToDouble(numOffsetLeadAVR.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadAVL_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadAVL].OffsetY = OffsetBase[(int)ECGLead.LeadAVL] + Convert.ToDouble(numOffsetLeadAVL.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadAVF_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadAVF].OffsetY = OffsetBase[(int)ECGLead.LeadAVF] + Convert.ToDouble(numOffsetLeadAVF.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadV1_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadV1].OffsetY = OffsetBase[(int)ECGLead.LeadV1] + Convert.ToDouble(numOffsetLeadV1.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadV2_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadV2].OffsetY = OffsetBase[(int)ECGLead.LeadV2] + Convert.ToDouble(numOffsetLeadV2.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadV3_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadV3].OffsetY = OffsetBase[(int)ECGLead.LeadV3] + Convert.ToDouble(numOffsetLeadV3.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadV4_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadV4].OffsetY = OffsetBase[(int)ECGLead.LeadV4] + Convert.ToDouble(numOffsetLeadV4.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadV5_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadV5].OffsetY = OffsetBase[(int)ECGLead.LeadV5] + Convert.ToDouble(numOffsetLeadV5.Value);
            plotRealtimeEKG.Render();
        }

        private void numOffsetLeadV6_ValueChanged(object sender, EventArgs e)
        {
            PlotECGLead[(int)ECGLead.LeadV6].OffsetY = OffsetBase[(int)ECGLead.LeadV6] + Convert.ToDouble(numOffsetLeadV6.Value);
            plotRealtimeEKG.Render();
        }

        /// <summary>
        /// Update tanggal dan jam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            PlotFooterDateTime.Label = DateTime.Now.ToString();
            plotRealtimeEKG.Render(skipIfCurrentlyRendering: true);
        }

        /// <summary>
        /// Reset identitas pasien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Reset_Click(object sender, EventArgs e)
        {
            tbRecord_Name.Text = "";
            PlotHeaderBirthDate.Label = "Tgl. Lahir: ";
            tbRecord_ID.Text = "0";
        }

        /// <summary>
        /// Update data pasien untuk direkam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRecord_Operator_TextChanged(object sender, EventArgs e)
        {
            PlotFooterOperator.Label = "Direkam oleh: ";
            PlotFooterOperator.Label += tbRecord_Operator.Text;
        }

        private void tbRecord_Name_TextChanged(object sender, EventArgs e)
        {
            PlotHeaderPatientName.Label = "Nama: ";
            PlotHeaderPatientName.Label += tbRecord_Name.Text;
        }

        private void dtRecord_BirthDate_ValueChanged(object sender, EventArgs e)
        {
            PlotHeaderBirthDate.Label = "Tgl. Lahir: ";
            PlotHeaderBirthDate.Label += dtRecord_BirthDate.Text;
        }

        private void tbRecord_Note_TextChanged(object sender, EventArgs e)
        {
            PlotHeaderNotes.Label = "CATATAN:" + Environment.NewLine;
            PlotHeaderNotes.Label += tbRecord_Note.Text;
        }

        private void cbRecord_Sex_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PlotHeaderSex.Label = "Jenis Kelamin: ";
            PlotHeaderSex.Label += cbRecord_Sex.SelectedItem.ToString();
        }

        private void tbRecord_ID_TextChanged(object sender, EventArgs e)
        {
            PlotHeaderPatientID.Label = "ID: ";
            PlotHeaderPatientID.Label += tbRecord_ID.Text;
        }

        /// <summary>
        /// Buka folder tempat rekaman EKG disimpan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Folder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"..\..\Rekaman EKG");
        }

        /// <summary>
        /// Mulai Rekam EKG
        /// Rekaman yang disimpan berupa file gambar PNG, dan file CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_StartRecord_Click(object sender, EventArgs e)
        {
            if (!serial.IsOpen)
            {
                MessageBox.Show("EKG tidak aktif!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BlockNum = 0;
                for (int ii = 0; ii < 12; ii++)
                {
                    Array.Clear(PlotECGBuffer[ii], 0, PlotECGBuffer[ii].Length);
                }
                plotRealtimeEKG.Render();
                lblECGDeviceStatus.Text = "Merekam...";
                lblECGDeviceStatus.BackColor = Color.Yellow;
                recordStart = true;
            }
        }

    }
}
