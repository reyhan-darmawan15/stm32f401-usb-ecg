
namespace Software_EKG_STM32
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.krLabelBuildVer = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.PageEKGRealtime = new Krypton.Navigator.KryptonPage();
            this.plotRealtimeEKG = new ScottPlot.FormsPlot();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnUSBConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.tbHeartRateDisplay = new System.Windows.Forms.TextBox();
            this.lblECGDeviceStatus = new System.Windows.Forms.Label();
            this.kryptonNavigator2 = new Krypton.Navigator.KryptonNavigator();
            this.krPageRecord = new Krypton.Navigator.KryptonPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbRecord_ID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tbRecord_Name = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dtRecord_BirthDate = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.cbRecord_Sex = new System.Windows.Forms.ComboBox();
            this.tbRecord_Operator = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRecord_Note = new System.Windows.Forms.TextBox();
            this.btnRecord_StartRecord = new System.Windows.Forms.Button();
            this.btnRecord_Reset = new System.Windows.Forms.Button();
            this.btnRecord_Folder = new System.Windows.Forms.Button();
            this.krPageSettingFilter = new Krypton.Navigator.KryptonPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.numOffsetLeadV6 = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.numOffsetLeadV5 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.numOffsetLeadV4 = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.numOffsetLeadV3 = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.numOffsetLeadV2 = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.numOffsetLeadV1 = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numOffsetLeadAVF = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.numOffsetLeadAVL = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.numOffsetLeadAVR = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numOffsetLeadIII = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numOffsetLeadII = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numOffsetLeadI = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterLP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbFilterHPOn = new System.Windows.Forms.CheckBox();
            this.chbFilter50Hz = new System.Windows.Forms.CheckBox();
            this.cbFilterHP = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbGainECG = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTimebaseECG = new System.Windows.Forms.ComboBox();
            this.PageInterpretasi = new Krypton.Navigator.KryptonPage();
            this.PageTentang = new Krypton.Navigator.KryptonPage();
            this.timerRenderRealtime = new System.Windows.Forms.Timer(this.components);
            this.workerRender = new System.ComponentModel.BackgroundWorker();
            this.timerUpdateTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageEKGRealtime)).BeginInit();
            this.PageEKGRealtime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPageRecord)).BeginInit();
            this.krPageRecord.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPageSettingFilter)).BeginInit();
            this.krPageSettingFilter.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadAVF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadAVL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadAVR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadIII)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadII)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadI)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageInterpretasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageTentang)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.krLabelBuildVer);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.MaximumSize = new System.Drawing.Size(0, 60);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelCustom1;
            this.kryptonPanel1.Size = new System.Drawing.Size(1264, 60);
            this.kryptonPanel1.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kryptonPanel1.StateNormal.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.kryptonPanel1.StateNormal.Color2 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPanel1.StateNormal.ColorAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.kryptonPanel1.StateNormal.ColorAngle = 0F;
            this.kryptonPanel1.StateNormal.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // krLabelBuildVer
            // 
            this.krLabelBuildVer.Dock = System.Windows.Forms.DockStyle.Right;
            this.krLabelBuildVer.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.krLabelBuildVer.Location = new System.Drawing.Point(1219, 0);
            this.krLabelBuildVer.Name = "krLabelBuildVer";
            this.krLabelBuildVer.Size = new System.Drawing.Size(45, 60);
            this.krLabelBuildVer.StateNormal.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.krLabelBuildVer.TabIndex = 4;
            this.krLabelBuildVer.Values.Text = "v1.0.0";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(83, 33);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(251, 23);
            this.kryptonLabel2.StateNormal.ShortText.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Jurusan Fisika FMIPA Universitas Lampung";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(83, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(263, 30);
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Agency FB", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "APLIKASI EKG 12 LEAD STM32F401";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(80, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.BarMapImage = Krypton.Navigator.MapKryptonPageImage.Large;
            this.kryptonNavigator1.Bar.BarMinimumHeight = 20;
            this.kryptonNavigator1.Bar.BarOrientation = Krypton.Toolkit.VisualOrientation.Left;
            this.kryptonNavigator1.Bar.CheckButtonStyle = Krypton.Toolkit.ButtonStyle.Cluster;
            this.kryptonNavigator1.Bar.ItemOrientation = Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.kryptonNavigator1.Bar.ItemSizing = Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 60);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.HeaderBarCheckButtonGroup;
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.PageEKGRealtime,
            this.PageInterpretasi,
            this.PageTentang});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1264, 621);
            this.kryptonNavigator1.TabIndex = 1;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // PageEKGRealtime
            // 
            this.PageEKGRealtime.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageEKGRealtime.Controls.Add(this.plotRealtimeEKG);
            this.PageEKGRealtime.Controls.Add(this.kryptonPanel2);
            this.PageEKGRealtime.Controls.Add(this.kryptonNavigator2);
            this.PageEKGRealtime.Flags = 65534;
            this.PageEKGRealtime.ImageLarge = global::Software_EKG_STM32.Properties.Resources.icon_monitor_32x32;
            this.PageEKGRealtime.LastVisibleSet = true;
            this.PageEKGRealtime.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageEKGRealtime.Name = "PageEKGRealtime";
            this.PageEKGRealtime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PageEKGRealtime.Size = new System.Drawing.Size(1262, 576);
            this.PageEKGRealtime.Text = "EKG Realtime";
            this.PageEKGRealtime.ToolTipTitle = "Page ToolTip";
            this.PageEKGRealtime.UniqueName = "6865506fa3ad4c5b85a616c80d430326";
            // 
            // plotRealtimeEKG
            // 
            this.plotRealtimeEKG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotRealtimeEKG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotRealtimeEKG.Location = new System.Drawing.Point(0, 32);
            this.plotRealtimeEKG.Name = "plotRealtimeEKG";
            this.plotRealtimeEKG.Size = new System.Drawing.Size(1082, 544);
            this.plotRealtimeEKG.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.panel1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.tbHeartRateDisplay);
            this.kryptonPanel2.Controls.Add(this.lblECGDeviceStatus);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.MaximumSize = new System.Drawing.Size(0, 32);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.TabDock;
            this.kryptonPanel2.Size = new System.Drawing.Size(1082, 32);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.kryptonPanel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnUSBConnect);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(889, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 32);
            this.panel1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(76, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // btnUSBConnect
            // 
            this.btnUSBConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUSBConnect.Image = global::Software_EKG_STM32.Properties.Resources.control_power;
            this.btnUSBConnect.Location = new System.Drawing.Point(144, 5);
            this.btnUSBConnect.Name = "btnUSBConnect";
            this.btnUSBConnect.Size = new System.Drawing.Size(43, 23);
            this.btnUSBConnect.TabIndex = 2;
            this.btnUSBConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUSBConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUSBConnect.UseVisualStyleBackColor = true;
            this.btnUSBConnect.Click += new System.EventHandler(this.btnUSBConnect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(4, 6);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Image = global::Software_EKG_STM32.Properties.Resources.computer_network;
            this.kryptonLabel4.Values.Text = "EKG";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(106, 6);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Image = global::Software_EKG_STM32.Properties.Resources.heart;
            this.kryptonLabel3.Values.Text = "Denyut (bpm)";
            this.kryptonLabel3.Visible = false;
            // 
            // tbHeartRateDisplay
            // 
            this.tbHeartRateDisplay.Font = new System.Drawing.Font("DSEG7 Modern", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeartRateDisplay.Location = new System.Drawing.Point(214, 6);
            this.tbHeartRateDisplay.Name = "tbHeartRateDisplay";
            this.tbHeartRateDisplay.ReadOnly = true;
            this.tbHeartRateDisplay.Size = new System.Drawing.Size(53, 19);
            this.tbHeartRateDisplay.TabIndex = 3;
            this.tbHeartRateDisplay.Text = "---";
            this.tbHeartRateDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHeartRateDisplay.Visible = false;
            // 
            // lblECGDeviceStatus
            // 
            this.lblECGDeviceStatus.AutoSize = true;
            this.lblECGDeviceStatus.BackColor = System.Drawing.Color.IndianRed;
            this.lblECGDeviceStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblECGDeviceStatus.Location = new System.Drawing.Point(51, 9);
            this.lblECGDeviceStatus.Name = "lblECGDeviceStatus";
            this.lblECGDeviceStatus.Size = new System.Drawing.Size(49, 15);
            this.lblECGDeviceStatus.TabIndex = 1;
            this.lblECGDeviceStatus.Text = "Nonaktif";
            // 
            // kryptonNavigator2
            // 
            this.kryptonNavigator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonNavigator2.Header.HeaderVisiblePrimary = false;
            this.kryptonNavigator2.Location = new System.Drawing.Point(1082, 0);
            this.kryptonNavigator2.MaximumSize = new System.Drawing.Size(180, 0);
            this.kryptonNavigator2.Name = "kryptonNavigator2";
            this.kryptonNavigator2.NavigatorMode = Krypton.Navigator.NavigatorMode.StackCheckButtonHeaderGroup;
            this.kryptonNavigator2.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.krPageRecord,
            this.krPageSettingFilter});
            this.kryptonNavigator2.SelectedIndex = 0;
            this.kryptonNavigator2.Size = new System.Drawing.Size(180, 576);
            this.kryptonNavigator2.TabIndex = 0;
            this.kryptonNavigator2.Text = "kryptonNavigator2";
            // 
            // krPageRecord
            // 
            this.krPageRecord.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPageRecord.Controls.Add(this.panel2);
            this.krPageRecord.Flags = 65534;
            this.krPageRecord.LastVisibleSet = true;
            this.krPageRecord.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPageRecord.Name = "krPageRecord";
            this.krPageRecord.Size = new System.Drawing.Size(178, 503);
            this.krPageRecord.Text = "Rekaman EKG";
            this.krPageRecord.TextDescription = "Perekaman EKG realtime";
            this.krPageRecord.ToolTipTitle = "Page ToolTip";
            this.krPageRecord.UniqueName = "b9bfd6d9ec6f47eca9768e4e94579a8b";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tbRecord_ID);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.tbRecord_Name);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.dtRecord_BirthDate);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.cbRecord_Sex);
            this.panel2.Controls.Add(this.tbRecord_Operator);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbRecord_Note);
            this.panel2.Controls.Add(this.btnRecord_StartRecord);
            this.panel2.Controls.Add(this.btnRecord_Reset);
            this.panel2.Controls.Add(this.btnRecord_Folder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 503);
            this.panel2.TabIndex = 18;
            // 
            // tbRecord_ID
            // 
            this.tbRecord_ID.Location = new System.Drawing.Point(8, 21);
            this.tbRecord_ID.MaxLength = 16;
            this.tbRecord_ID.Name = "tbRecord_ID";
            this.tbRecord_ID.Size = new System.Drawing.Size(157, 20);
            this.tbRecord_ID.TabIndex = 4;
            this.tbRecord_ID.Text = "0";
            this.tbRecord_ID.TextChanged += new System.EventHandler(this.tbRecord_ID_TextChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(5, 5);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(20, 13);
            this.label29.TabIndex = 5;
            this.label29.Text = "ID";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(5, 48);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(81, 13);
            this.label30.TabIndex = 6;
            this.label30.Text = "Nama Pasien";
            // 
            // tbRecord_Name
            // 
            this.tbRecord_Name.Location = new System.Drawing.Point(8, 64);
            this.tbRecord_Name.Name = "tbRecord_Name";
            this.tbRecord_Name.Size = new System.Drawing.Size(157, 20);
            this.tbRecord_Name.TabIndex = 7;
            this.tbRecord_Name.TextChanged += new System.EventHandler(this.tbRecord_Name_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(5, 96);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(85, 13);
            this.label32.TabIndex = 9;
            this.label32.Text = "Tanggal Lahir";
            // 
            // dtRecord_BirthDate
            // 
            this.dtRecord_BirthDate.CustomFormat = "dddd dd/MM/yyyy";
            this.dtRecord_BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRecord_BirthDate.Location = new System.Drawing.Point(8, 113);
            this.dtRecord_BirthDate.Name = "dtRecord_BirthDate";
            this.dtRecord_BirthDate.Size = new System.Drawing.Size(155, 20);
            this.dtRecord_BirthDate.TabIndex = 11;
            this.dtRecord_BirthDate.ValueChanged += new System.EventHandler(this.dtRecord_BirthDate_ValueChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(5, 144);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 13);
            this.label28.TabIndex = 12;
            this.label28.Text = "Jenis Kelamin";
            // 
            // cbRecord_Sex
            // 
            this.cbRecord_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecord_Sex.FormattingEnabled = true;
            this.cbRecord_Sex.Items.AddRange(new object[] {
            "",
            "Laki-Laki",
            "Perempuan"});
            this.cbRecord_Sex.Location = new System.Drawing.Point(8, 163);
            this.cbRecord_Sex.Name = "cbRecord_Sex";
            this.cbRecord_Sex.Size = new System.Drawing.Size(155, 21);
            this.cbRecord_Sex.TabIndex = 13;
            this.cbRecord_Sex.SelectionChangeCommitted += new System.EventHandler(this.cbRecord_Sex_SelectionChangeCommitted);
            // 
            // tbRecord_Operator
            // 
            this.tbRecord_Operator.Location = new System.Drawing.Point(7, 212);
            this.tbRecord_Operator.Name = "tbRecord_Operator";
            this.tbRecord_Operator.Size = new System.Drawing.Size(155, 20);
            this.tbRecord_Operator.TabIndex = 14;
            this.tbRecord_Operator.TextChanged += new System.EventHandler(this.tbRecord_Operator_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(5, 193);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(56, 13);
            this.label33.TabIndex = 15;
            this.label33.Text = "Operator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Catatan:";
            // 
            // tbRecord_Note
            // 
            this.tbRecord_Note.AcceptsReturn = true;
            this.tbRecord_Note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRecord_Note.Location = new System.Drawing.Point(8, 262);
            this.tbRecord_Note.Multiline = true;
            this.tbRecord_Note.Name = "tbRecord_Note";
            this.tbRecord_Note.Size = new System.Drawing.Size(158, 169);
            this.tbRecord_Note.TabIndex = 20;
            this.tbRecord_Note.TextChanged += new System.EventHandler(this.tbRecord_Note_TextChanged);
            // 
            // btnRecord_StartRecord
            // 
            this.btnRecord_StartRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecord_StartRecord.Image = global::Software_EKG_STM32.Properties.Resources.control_record;
            this.btnRecord_StartRecord.Location = new System.Drawing.Point(11, 443);
            this.btnRecord_StartRecord.Name = "btnRecord_StartRecord";
            this.btnRecord_StartRecord.Size = new System.Drawing.Size(49, 54);
            this.btnRecord_StartRecord.TabIndex = 3;
            this.btnRecord_StartRecord.Text = "Rekam";
            this.btnRecord_StartRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord_StartRecord.UseVisualStyleBackColor = true;
            this.btnRecord_StartRecord.Click += new System.EventHandler(this.btnRecord_StartRecord_Click);
            // 
            // btnRecord_Reset
            // 
            this.btnRecord_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecord_Reset.Image = global::Software_EKG_STM32.Properties.Resources.arrow_return_180_left;
            this.btnRecord_Reset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecord_Reset.Location = new System.Drawing.Point(121, 443);
            this.btnRecord_Reset.Name = "btnRecord_Reset";
            this.btnRecord_Reset.Size = new System.Drawing.Size(50, 54);
            this.btnRecord_Reset.TabIndex = 17;
            this.btnRecord_Reset.Text = "Reset";
            this.btnRecord_Reset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecord_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord_Reset.UseVisualStyleBackColor = true;
            this.btnRecord_Reset.Click += new System.EventHandler(this.btnRecord_Reset_Click);
            // 
            // btnRecord_Folder
            // 
            this.btnRecord_Folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecord_Folder.Image = global::Software_EKG_STM32.Properties.Resources.folder;
            this.btnRecord_Folder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecord_Folder.Location = new System.Drawing.Point(66, 443);
            this.btnRecord_Folder.Name = "btnRecord_Folder";
            this.btnRecord_Folder.Size = new System.Drawing.Size(49, 54);
            this.btnRecord_Folder.TabIndex = 16;
            this.btnRecord_Folder.Text = "Buka Folder";
            this.btnRecord_Folder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecord_Folder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecord_Folder.UseVisualStyleBackColor = true;
            this.btnRecord_Folder.Click += new System.EventHandler(this.btnRecord_Folder_Click);
            // 
            // krPageSettingFilter
            // 
            this.krPageSettingFilter.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPageSettingFilter.AutoScroll = true;
            this.krPageSettingFilter.Controls.Add(this.groupBox4);
            this.krPageSettingFilter.Controls.Add(this.groupBox1);
            this.krPageSettingFilter.Controls.Add(this.groupBox2);
            this.krPageSettingFilter.Controls.Add(this.groupBox3);
            this.krPageSettingFilter.Flags = 65534;
            this.krPageSettingFilter.LastVisibleSet = true;
            this.krPageSettingFilter.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPageSettingFilter.Name = "krPageSettingFilter";
            this.krPageSettingFilter.Padding = new System.Windows.Forms.Padding(5);
            this.krPageSettingFilter.Size = new System.Drawing.Size(178, 503);
            this.krPageSettingFilter.Text = "Pengaturan EKG";
            this.krPageSettingFilter.TextDescription = "Pengaturan EKG";
            this.krPageSettingFilter.ToolTipTitle = "Page ToolTip";
            this.krPageSettingFilter.UniqueName = "7f5f3fc8fff540a98e694fb6b1ce69cc";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.numOffsetLeadV6);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.numOffsetLeadV5);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.numOffsetLeadV4);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.numOffsetLeadV3);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.numOffsetLeadV2);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.numOffsetLeadV1);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.numOffsetLeadAVF);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.numOffsetLeadAVL);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.numOffsetLeadAVR);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.numOffsetLeadIII);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.numOffsetLeadII);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.numOffsetLeadI);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(5, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 310);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Offset (mm)";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 286);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(20, 13);
            this.label27.TabIndex = 23;
            this.label27.Text = "V6";
            // 
            // numOffsetLeadV6
            // 
            this.numOffsetLeadV6.DecimalPlaces = 1;
            this.numOffsetLeadV6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadV6.Location = new System.Drawing.Point(48, 284);
            this.numOffsetLeadV6.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadV6.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadV6.Name = "numOffsetLeadV6";
            this.numOffsetLeadV6.ReadOnly = true;
            this.numOffsetLeadV6.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadV6.TabIndex = 22;
            this.numOffsetLeadV6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadV6.ValueChanged += new System.EventHandler(this.numOffsetLeadV6_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 262);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 13);
            this.label26.TabIndex = 21;
            this.label26.Text = "V5";
            // 
            // numOffsetLeadV5
            // 
            this.numOffsetLeadV5.DecimalPlaces = 1;
            this.numOffsetLeadV5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadV5.Location = new System.Drawing.Point(48, 260);
            this.numOffsetLeadV5.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadV5.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadV5.Name = "numOffsetLeadV5";
            this.numOffsetLeadV5.ReadOnly = true;
            this.numOffsetLeadV5.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadV5.TabIndex = 20;
            this.numOffsetLeadV5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadV5.ValueChanged += new System.EventHandler(this.numOffsetLeadV5_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 238);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(20, 13);
            this.label25.TabIndex = 19;
            this.label25.Text = "V4";
            // 
            // numOffsetLeadV4
            // 
            this.numOffsetLeadV4.DecimalPlaces = 1;
            this.numOffsetLeadV4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadV4.Location = new System.Drawing.Point(48, 236);
            this.numOffsetLeadV4.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadV4.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadV4.Name = "numOffsetLeadV4";
            this.numOffsetLeadV4.ReadOnly = true;
            this.numOffsetLeadV4.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadV4.TabIndex = 18;
            this.numOffsetLeadV4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadV4.ValueChanged += new System.EventHandler(this.numOffsetLeadV4_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 214);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 13);
            this.label24.TabIndex = 17;
            this.label24.Text = "V3";
            // 
            // numOffsetLeadV3
            // 
            this.numOffsetLeadV3.DecimalPlaces = 1;
            this.numOffsetLeadV3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadV3.Location = new System.Drawing.Point(48, 212);
            this.numOffsetLeadV3.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadV3.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadV3.Name = "numOffsetLeadV3";
            this.numOffsetLeadV3.ReadOnly = true;
            this.numOffsetLeadV3.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadV3.TabIndex = 16;
            this.numOffsetLeadV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadV3.ValueChanged += new System.EventHandler(this.numOffsetLeadV3_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 190);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(20, 13);
            this.label23.TabIndex = 15;
            this.label23.Text = "V2";
            // 
            // numOffsetLeadV2
            // 
            this.numOffsetLeadV2.DecimalPlaces = 1;
            this.numOffsetLeadV2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadV2.Location = new System.Drawing.Point(48, 188);
            this.numOffsetLeadV2.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadV2.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadV2.Name = "numOffsetLeadV2";
            this.numOffsetLeadV2.ReadOnly = true;
            this.numOffsetLeadV2.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadV2.TabIndex = 14;
            this.numOffsetLeadV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadV2.ValueChanged += new System.EventHandler(this.numOffsetLeadV2_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 166);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "V1";
            // 
            // numOffsetLeadV1
            // 
            this.numOffsetLeadV1.DecimalPlaces = 1;
            this.numOffsetLeadV1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadV1.Location = new System.Drawing.Point(48, 164);
            this.numOffsetLeadV1.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadV1.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadV1.Name = "numOffsetLeadV1";
            this.numOffsetLeadV1.ReadOnly = true;
            this.numOffsetLeadV1.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadV1.TabIndex = 12;
            this.numOffsetLeadV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadV1.ValueChanged += new System.EventHandler(this.numOffsetLeadV1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 142);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "aVF";
            // 
            // numOffsetLeadAVF
            // 
            this.numOffsetLeadAVF.DecimalPlaces = 1;
            this.numOffsetLeadAVF.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadAVF.Location = new System.Drawing.Point(48, 140);
            this.numOffsetLeadAVF.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadAVF.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadAVF.Name = "numOffsetLeadAVF";
            this.numOffsetLeadAVF.ReadOnly = true;
            this.numOffsetLeadAVF.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadAVF.TabIndex = 10;
            this.numOffsetLeadAVF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadAVF.ValueChanged += new System.EventHandler(this.numOffsetLeadAVF_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 117);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "aVL";
            // 
            // numOffsetLeadAVL
            // 
            this.numOffsetLeadAVL.DecimalPlaces = 1;
            this.numOffsetLeadAVL.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadAVL.Location = new System.Drawing.Point(48, 115);
            this.numOffsetLeadAVL.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadAVL.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadAVL.Name = "numOffsetLeadAVL";
            this.numOffsetLeadAVL.ReadOnly = true;
            this.numOffsetLeadAVL.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadAVL.TabIndex = 8;
            this.numOffsetLeadAVL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadAVL.ValueChanged += new System.EventHandler(this.numOffsetLeadAVL_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "aVR";
            // 
            // numOffsetLeadAVR
            // 
            this.numOffsetLeadAVR.DecimalPlaces = 1;
            this.numOffsetLeadAVR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadAVR.Location = new System.Drawing.Point(48, 91);
            this.numOffsetLeadAVR.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadAVR.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadAVR.Name = "numOffsetLeadAVR";
            this.numOffsetLeadAVR.ReadOnly = true;
            this.numOffsetLeadAVR.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadAVR.TabIndex = 6;
            this.numOffsetLeadAVR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadAVR.ValueChanged += new System.EventHandler(this.numOffsetLeadAVR_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "III";
            // 
            // numOffsetLeadIII
            // 
            this.numOffsetLeadIII.DecimalPlaces = 1;
            this.numOffsetLeadIII.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadIII.Location = new System.Drawing.Point(48, 67);
            this.numOffsetLeadIII.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadIII.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadIII.Name = "numOffsetLeadIII";
            this.numOffsetLeadIII.ReadOnly = true;
            this.numOffsetLeadIII.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadIII.TabIndex = 4;
            this.numOffsetLeadIII.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadIII.ValueChanged += new System.EventHandler(this.numOffsetLeadIII_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "II";
            // 
            // numOffsetLeadII
            // 
            this.numOffsetLeadII.DecimalPlaces = 1;
            this.numOffsetLeadII.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadII.Location = new System.Drawing.Point(48, 43);
            this.numOffsetLeadII.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadII.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadII.Name = "numOffsetLeadII";
            this.numOffsetLeadII.ReadOnly = true;
            this.numOffsetLeadII.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadII.TabIndex = 2;
            this.numOffsetLeadII.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadII.ValueChanged += new System.EventHandler(this.numOffsetLeadII_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "I";
            // 
            // numOffsetLeadI
            // 
            this.numOffsetLeadI.DecimalPlaces = 1;
            this.numOffsetLeadI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffsetLeadI.Location = new System.Drawing.Point(48, 19);
            this.numOffsetLeadI.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numOffsetLeadI.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147418112});
            this.numOffsetLeadI.Name = "numOffsetLeadI";
            this.numOffsetLeadI.ReadOnly = true;
            this.numOffsetLeadI.Size = new System.Drawing.Size(81, 20);
            this.numOffsetLeadI.TabIndex = 0;
            this.numOffsetLeadI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOffsetLeadI.ValueChanged += new System.EventHandler(this.numOffsetLeadI_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbFilterLP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chbFilterHPOn);
            this.groupBox1.Controls.Add(this.chbFilter50Hz);
            this.groupBox1.Controls.Add(this.cbFilterHP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 146);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Low-Pass Filter";
            // 
            // cbFilterLP
            // 
            this.cbFilterLP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterLP.FormattingEnabled = true;
            this.cbFilterLP.Items.AddRange(new object[] {
            "40 Hz",
            "75 Hz",
            "150 Hz"});
            this.cbFilterLP.Location = new System.Drawing.Point(8, 36);
            this.cbFilterLP.Name = "cbFilterLP";
            this.cbFilterLP.Size = new System.Drawing.Size(121, 21);
            this.cbFilterLP.TabIndex = 1;
            this.cbFilterLP.SelectionChangeCommitted += new System.EventHandler(this.cbFilterLP_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "High-Pass Filter";
            // 
            // chbFilterHPOn
            // 
            this.chbFilterHPOn.AutoSize = true;
            this.chbFilterHPOn.BackColor = System.Drawing.Color.Transparent;
            this.chbFilterHPOn.Location = new System.Drawing.Point(88, 65);
            this.chbFilterHPOn.Name = "chbFilterHPOn";
            this.chbFilterHPOn.Size = new System.Drawing.Size(47, 17);
            this.chbFilterHPOn.TabIndex = 4;
            this.chbFilterHPOn.Text = "Aktif";
            this.chbFilterHPOn.UseVisualStyleBackColor = false;
            this.chbFilterHPOn.CheckedChanged += new System.EventHandler(this.chbFilterHPOn_CheckedChanged);
            // 
            // chbFilter50Hz
            // 
            this.chbFilter50Hz.AutoSize = true;
            this.chbFilter50Hz.BackColor = System.Drawing.Color.Transparent;
            this.chbFilter50Hz.Location = new System.Drawing.Point(6, 121);
            this.chbFilter50Hz.Name = "chbFilter50Hz";
            this.chbFilter50Hz.Size = new System.Drawing.Size(126, 17);
            this.chbFilter50Hz.TabIndex = 5;
            this.chbFilter50Hz.Text = "Reduksi Noise 50 Hz";
            this.chbFilter50Hz.UseVisualStyleBackColor = false;
            this.chbFilter50Hz.CheckedChanged += new System.EventHandler(this.chbFilter50Hz_CheckedChanged);
            // 
            // cbFilterHP
            // 
            this.cbFilterHP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterHP.FormattingEnabled = true;
            this.cbFilterHP.Items.AddRange(new object[] {
            "0,25 Hz",
            "0,5 Hz"});
            this.cbFilterHP.Location = new System.Drawing.Point(8, 85);
            this.cbFilterHP.Name = "cbFilterHP";
            this.cbFilterHP.Size = new System.Drawing.Size(121, 21);
            this.cbFilterHP.TabIndex = 3;
            this.cbFilterHP.SelectionChangeCommitted += new System.EventHandler(this.cbFilterHP_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbGainECG);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 46);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gain";
            // 
            // cbGainECG
            // 
            this.cbGainECG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGainECG.FormattingEnabled = true;
            this.cbGainECG.Items.AddRange(new object[] {
            "5 mm/mV",
            "10 mm/mV",
            "20 mm/mV"});
            this.cbGainECG.Location = new System.Drawing.Point(8, 18);
            this.cbGainECG.Name = "cbGainECG";
            this.cbGainECG.Size = new System.Drawing.Size(121, 21);
            this.cbGainECG.TabIndex = 1;
            this.cbGainECG.SelectionChangeCommitted += new System.EventHandler(this.cbGainECG_SelectionChangeCommitted);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cbTimebaseECG);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(5, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 49);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Timebase";
            // 
            // cbTimebaseECG
            // 
            this.cbTimebaseECG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimebaseECG.FormattingEnabled = true;
            this.cbTimebaseECG.Items.AddRange(new object[] {
            "25 mm/s",
            "50 mm/s"});
            this.cbTimebaseECG.Location = new System.Drawing.Point(8, 19);
            this.cbTimebaseECG.Name = "cbTimebaseECG";
            this.cbTimebaseECG.Size = new System.Drawing.Size(121, 21);
            this.cbTimebaseECG.TabIndex = 0;
            this.cbTimebaseECG.SelectionChangeCommitted += new System.EventHandler(this.cbTimebaseECG_SelectionChangeCommitted);
            // 
            // PageInterpretasi
            // 
            this.PageInterpretasi.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageInterpretasi.Flags = 65534;
            this.PageInterpretasi.ImageLarge = global::Software_EKG_STM32.Properties.Resources.icon_stats_histogram_32x32;
            this.PageInterpretasi.LastVisibleSet = true;
            this.PageInterpretasi.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageInterpretasi.Name = "PageInterpretasi";
            this.PageInterpretasi.Size = new System.Drawing.Size(1262, 576);
            this.PageInterpretasi.Text = "Analisis EKG";
            this.PageInterpretasi.ToolTipTitle = "Page ToolTip";
            this.PageInterpretasi.UniqueName = "474852fecc26482c82eea18fe6f8bc17";
            this.PageInterpretasi.Visible = false;
            // 
            // PageTentang
            // 
            this.PageTentang.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.PageTentang.Flags = 65534;
            this.PageTentang.ImageLarge = global::Software_EKG_STM32.Properties.Resources.icon_our_team_32x32;
            this.PageTentang.LastVisibleSet = true;
            this.PageTentang.MinimumSize = new System.Drawing.Size(50, 50);
            this.PageTentang.Name = "PageTentang";
            this.PageTentang.Size = new System.Drawing.Size(1262, 576);
            this.PageTentang.Text = "Tentang";
            this.PageTentang.ToolTipTitle = "Page ToolTip";
            this.PageTentang.UniqueName = "19414894ca8a4982a2e64fb634e0a073";
            this.PageTentang.Visible = false;
            // 
            // timerRenderRealtime
            // 
            this.timerRenderRealtime.Enabled = true;
            this.timerRenderRealtime.Interval = 30;
            this.timerRenderRealtime.Tick += new System.EventHandler(this.timerRenderRealtime_Tick);
            // 
            // workerRender
            // 
            this.workerRender.WorkerSupportsCancellation = true;
            this.workerRender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerRender_DoWork);
            this.workerRender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerRender_RunWorkerCompleted);
            // 
            // timerUpdateTime
            // 
            this.timerUpdateTime.Enabled = true;
            this.timerUpdateTime.Interval = 1000;
            this.timerUpdateTime.Tick += new System.EventHandler(this.timerUpdateTime_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplikasi EKG 12 Lead STM32F401";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PageEKGRealtime)).EndInit();
            this.PageEKGRealtime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPageRecord)).EndInit();
            this.krPageRecord.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPageSettingFilter)).EndInit();
            this.krPageSettingFilter.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadAVF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadAVL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadAVR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadIII)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadII)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetLeadI)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PageInterpretasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageTentang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private Krypton.Navigator.KryptonPage PageEKGRealtime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Krypton.Navigator.KryptonPage PageTentang;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel krLabelBuildVer;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator2;
        private Krypton.Navigator.KryptonPage krPageSettingFilter;
        private ScottPlot.FormsPlot plotRealtimeEKG;
        private Krypton.Navigator.KryptonPage PageInterpretasi;
        private Krypton.Navigator.KryptonPage krPageRecord;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUSBConnect;
        private System.Windows.Forms.ComboBox cbFilterLP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbFilterHPOn;
        private System.Windows.Forms.ComboBox cbFilterHP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbFilter50Hz;
        private System.Windows.Forms.Timer timerRenderRealtime;
        private System.Windows.Forms.Button btnRecord_StartRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbTimebaseECG;
        private System.Windows.Forms.ComboBox cbGainECG;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numOffsetLeadV6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numOffsetLeadV5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numOffsetLeadV4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown numOffsetLeadV3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numOffsetLeadV2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numOffsetLeadV1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numOffsetLeadAVF;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numOffsetLeadAVL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numOffsetLeadAVR;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numOffsetLeadIII;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numOffsetLeadII;
        private System.Windows.Forms.NumericUpDown numOffsetLeadI;
        private System.ComponentModel.BackgroundWorker workerRender;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tbRecord_ID;
        private System.Windows.Forms.TextBox tbRecord_Name;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Timer timerUpdateTime;
        private System.Windows.Forms.Label lblECGDeviceStatus;
        private System.Windows.Forms.TextBox tbHeartRateDisplay;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.DateTimePicker dtRecord_BirthDate;
        private System.Windows.Forms.TextBox tbRecord_Operator;
        private System.Windows.Forms.ComboBox cbRecord_Sex;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRecord_Folder;
        private System.Windows.Forms.Button btnRecord_Reset;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbRecord_Note;
        private System.Windows.Forms.Label label4;
    }
}

