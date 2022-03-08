/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2022 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "dma.h"
#include "tim.h"
#include "usart.h"
#include "usb_device.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "usbd_cdc_if.h"
#include "dsp_filter.h"
#include "stdio.h"
#include "stdlib.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */
typedef enum
{
	CMD_LED = 'L',
	CMD_MUX = 'C',
	CMD_SH  = 'S',
	CMD_ADC = 'A',
	CMD_DAC = 'D',
	CMD_ACQ = 'B'
} AFE_CmdType;
AFE_CmdType cmdType;

typedef enum
{
	CMD_LED_OFF   = 0x0000,
	CMD_LED_ON    = 0x0001,
	CMD_SH_HOLD   = 0x0000,
	CMD_SH_SAMPLE = 0x0001,
	CMD_MUX_R_F   = 0x0005,
	CMD_MUX_L_F   = 0x0004,
	CMD_MUX_C1_F  = 0x0000,
	CMD_MUX_C2_F  = 0x0006,
	CMD_MUX_C3_F  = 0x0007,
	CMD_MUX_C4_F  = 0x0002,
	CMD_MUX_C5_F  = 0x0001,
	CMD_MUX_C6_F  = 0x0003
} AFE_CmdValue;
AFE_CmdValue cmdValue;
/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
// Filter

// Buffer untuk menyimpan data dari AFE
volatile uint16_t AFE_ADCRawData[8]; 			// Urutan ADC2 R-F, L-F, C1-F, ..., C6-F
volatile float DSP_ECGInputData[8];			// ADC2 dikonversi ke tegangan (mV)
volatile int16_t DSP_ECGOutputData[160];
volatile const float DSP_ADCToMillivoltScale = 0.000794728597;
volatile const float DSP_MillivoltToADCScale = 1258.2912;

volatile DSP_STFilter stFilter[8];
volatile DSP_LowPassFilter lpFilter[8];
volatile DSP_HighPassFilter hpFilter[8];
volatile DSP_PowerLineFilter plFilter[8];

volatile uint8_t isDataReady = 0;
volatile uint8_t txUsbBufferCount = 0;

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_USART1_UART_Init();
  MX_TIM1_Init();
  MX_TIM2_Init();
  MX_TIM3_Init();
  MX_TIM9_Init();
  MX_USB_DEVICE_Init();
  /* USER CODE BEGIN 2 */

  HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_3);
  TIM2->CCR3 = 0;

  // Inisialisasi AFE

  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */

	// Mulai pengolahan sinyal
	if(isDataReady == 1)
	{
		for(int8_t i=0; i<8; i++)
		{
			// ST Filter ---> HPF ---> LPF ---> Powerline Filter
			// 1. ST Filter 0,05 Hz
			stFilter[i].x = DSP_ECGInputData[i];
			stFilter[i].b0 = STFilt_b0;
			stFilter[i].b1 = STFilt_b1;
			stFilter[i].a1 = STFilt_a1;
			stFilter[i].w1 = stFilter[i].w0;
			stFilter[i].w0 = stFilter[i].x - stFilter[i].a1*stFilter[i].w1;
			stFilter[i].y  = stFilter[i].b0*stFilter[i].w0 + stFilter[i].b1*stFilter[i].w1;
			if(stFilter[i].y > 5.000) stFilter[i].y = 5.000;
			if(stFilter[i].y < -5.000) stFilter[i].y = -5.000;

			// 2. High Pass Filter
			hpFilter[i].x = stFilter[i].y;
			if(hpFilter[i].isFilterOn == 1)
			{
				hpFilter[i].w1 = hpFilter[i].w0;
				hpFilter[i].w0 = hpFilter[i].x - hpFilter[i].a1*hpFilter[i].w1;
				hpFilter[i].y  = hpFilter[i].b0*hpFilter[i].w0 + hpFilter[i].b1*hpFilter[i].w1;
			}
			else
			{
				hpFilter[i].y = hpFilter[i].x;
			}
			if(hpFilter[i].y > 5.000) hpFilter[i].y = 5.000;
			if(hpFilter[i].y < -5.000) hpFilter[i].y = -5.000;

			// 3. Low Pass Filter
			lpFilter[i].x = hpFilter[i].y;
			lpFilter[i].w12 = lpFilter[i].w11;
			lpFilter[i].w11 = lpFilter[i].w10;
			lpFilter[i].w10 = lpFilter[i].x*lpFilter[i].K1 - lpFilter[i].w11*lpFilter[i].a11 - lpFilter[i].w12*lpFilter[i].a12;
			// Hitung output section 1
			lpFilter[i].y1 = lpFilter[i].w10 + 2*lpFilter[i].w11 + lpFilter[i].w12;
			// Update buffer section 2
			lpFilter[i].w22 = lpFilter[i].w21;
			lpFilter[i].w21 = lpFilter[i].w20;
			lpFilter[i].w20 = lpFilter[i].y1*lpFilter[i].K2 - lpFilter[i].w21*lpFilter[i].a21 - lpFilter[i].w22*lpFilter[i].a22;
			// Hitung output section 2
			lpFilter[i].y2 = lpFilter[i].w20 + 2*lpFilter[i].w21 + lpFilter[i].w22;
			if(lpFilter[i].y2 > 5.000) lpFilter[i].y2 = 5.000;
			if(lpFilter[i].y2 < -5.000) lpFilter[i].y2 = -5.000;

			// 4. Power Line Filter
			// To-do: implementasi metode subtraksi
			plFilter[i].x = lpFilter[i].y2;
			if(plFilter[i].isFilterOn == 1)
			{
				// plFilter[i].Buffer[plFilter[i].Ptr] = plFilter[i].x;
				// plFilter[i].y += 0.1 * (plFilter[i].Buffer[plFilter[i].Ptr] - plFilter[i].Buffer[(plFilter[i].Ptr - 10) & 15]);

				// Update DBuffer (delay buffer)
				plFilter[i].DBuffer[plFilter[i].Ptr] = plFilter[i].x;

				// Hitung K-filter Update BBuffer (FIFO buffer menyimpan sinyal interferensi)
				plFilter[i].Kf += 0.1 * (plFilter[i].DBuffer[(plFilter[i].Ptr-4) & 31] - plFilter[i].DBuffer[(plFilter[i].Ptr-14) & 31]);
				plFilter[i].BBuffer[(plFilter[i].Ptr-4) & 31] = plFilter[i].DBuffer[(plFilter[i].Ptr-9) & 31] - plFilter[i].Kf;

				// Hitung D-filter
				plFilter[i].Df = plFilter[i].DBuffer[(plFilter[i].Ptr-19) & 31] - 2.0*plFilter[i].DBuffer[(plFilter[i].Ptr-9) & 31] + plFilter[i].DBuffer[plFilter[i].Ptr];
				plFilter[i].Df *= plFilter[i].Df;

				// Subtraksi berdasarkan kriteria linear
				if(plFilter[i].Df < 0.24)
				{
					plFilter[i].y = plFilter[i].DBuffer[(plFilter[i].Ptr-9) & 31] - plFilter[i].BBuffer[(plFilter[i].Ptr-4) & 31];
				}
				else
				{
					plFilter[i].BBuffer[(plFilter[i].Ptr-4) & 31] = plFilter[i].BBuffer[(plFilter[i].Ptr-14) & 31];
					plFilter[i].y = plFilter[i].DBuffer[(plFilter[i].Ptr-9) & 31] - plFilter[i].BBuffer[(plFilter[i].Ptr-14) & 31];
				}

				// Update pointer setiap fungsi ini diambil
				plFilter[i].Ptr = (plFilter[i].Ptr + 1) & 31;
			}
			else
			{
				plFilter[i].y = plFilter[i].x;
			}
			if(plFilter[i].y > 5.000) plFilter[i].y = 5.000;
			if(plFilter[i].y < -5.000) plFilter[i].y = -5.000;

			// Simpan di buffer
			DSP_ECGOutputData[(txUsbBufferCount * 8) + i] = (int16_t)(plFilter[i].y * DSP_MillivoltToADCScale);
		}
		if(txUsbBufferCount == 19)
		{
			CDC_Transmit_FS((uint8_t*)DSP_ECGOutputData, 320);
		}
		txUsbBufferCount = (txUsbBufferCount + 1) % 20;
		isDataReady = 0;
	}
	// Update pengaturan DSP
	if(usbCmd->updated == 0x01)
	{
		switch(usbCmd->command)
		{
			case 'H':	// Pengaturan HPF
				for(int8_t i=7; i>-1; i--)
				{
					if(usbCmd->value == 0)	// Nonaktifkan HPF
					{
						hpFilter[i].isFilterOn = 0;
					}
					if(usbCmd->value == 1)	// HPF 0.25 Hz
					{
						hpFilter[i].isFilterOn = 1;
						// Reset filter
						hpFilter[i].w0 = 0.0;
						hpFilter[i].w1 = 0.0;
						// Set filter
						hpFilter[i].b0 = HPF_b0_025Hz;
						hpFilter[i].b1 = HPF_b1_025Hz;
						hpFilter[i].a1 = HPF_a1_025Hz;
					}
					if(usbCmd->value == 2)	// HPF 0.5 Hz
					{
						hpFilter[i].isFilterOn = 1;
						// Reset filter
						hpFilter[i].w0 = 0.0;
						hpFilter[i].w1 = 0.0;
						// Set filter
						hpFilter[i].b0 = HPF_b0_050Hz;
						hpFilter[i].b1 = HPF_b1_050Hz;
						hpFilter[i].a1 = HPF_a1_050Hz;
					}
				}
				break;
			case 'L':	// Pengaturan LPF
				for(int8_t i=7; i>-1; i--)
				{
					if(usbCmd->value == 0)	// LPF 40 Hz
					{
						// Reset filter
						lpFilter[i].w10 = 0.0;
						lpFilter[i].w11 = 0.0;
						lpFilter[i].w12 = 0.0;
						lpFilter[i].w20 = 0.0;
						lpFilter[i].w21 = 0.0;
						lpFilter[i].w22 = 0.0;
						// Set pengaturan filter
						lpFilter[i].K1  = LPF_K_40Hz[0];
						lpFilter[i].K2  = LPF_K_40Hz[1];
						lpFilter[i].a11 = LPF_a1_40Hz[1];
						lpFilter[i].a12 = LPF_a1_40Hz[2];
						lpFilter[i].a21 = LPF_a2_40Hz[1];
						lpFilter[i].a22 = LPF_a2_40Hz[2];
					}
					if(usbCmd->value == 1)	// LPF 75 Hz
					{
						// Reset filter
						lpFilter[i].w10 = 0.0;
						lpFilter[i].w11 = 0.0;
						lpFilter[i].w12 = 0.0;
						lpFilter[i].w20 = 0.0;
						lpFilter[i].w21 = 0.0;
						lpFilter[i].w22 = 0.0;
						// Set pengaturan filter
						lpFilter[i].K1  = LPF_K_75Hz[0];
						lpFilter[i].K2  = LPF_K_75Hz[1];
						lpFilter[i].a11 = LPF_a1_75Hz[1];
						lpFilter[i].a12 = LPF_a1_75Hz[2];
						lpFilter[i].a21 = LPF_a2_75Hz[1];
						lpFilter[i].a22 = LPF_a2_75Hz[2];
					}
					if(usbCmd->value == 2)	// LPF 150 Hz
					{
						// Reset filter
						lpFilter[i].w10 = 0.0;
						lpFilter[i].w11 = 0.0;
						lpFilter[i].w12 = 0.0;
						lpFilter[i].w20 = 0.0;
						lpFilter[i].w21 = 0.0;
						lpFilter[i].w22 = 0.0;
						// Set pengaturan filter
						lpFilter[i].K1  = LPF_K_150Hz[0];
						lpFilter[i].K2  = LPF_K_150Hz[1];
						lpFilter[i].a11 = LPF_a1_150Hz[1];
						lpFilter[i].a12 = LPF_a1_150Hz[2];
						lpFilter[i].a21 = LPF_a2_150Hz[1];
						lpFilter[i].a22 = LPF_a2_150Hz[2];
					}
				}
				break;
			case 'P':	// Pengaturan powerline filter
				for (int8_t i=7; i>-1; i--)
				{
					if(usbCmd->value == 0)	// Powerline filter off
					{
						plFilter[i].isFilterOn = 0;
					}
					if(usbCmd->value == 1)	// Powerline filter on
					{
						plFilter[i].isFilterOn = 1;
					}
				}
				break;
			case 'R':	// Pengaturan kedip LED hijau
				if(usbCmd->value != 0)
				{
					TIM2->CCR3 = 299;
					if(usbCmd->value > 4999)
					{
						TIM2->ARR = 4999;	// Minimum 24 bpm
					}
					else if(usbCmd->value < 331)
					{
						TIM2->ARR = 331;   // Maksimum 360 bpm
					}
					else
					{
						TIM2->ARR = usbCmd->value;
					}
				}
				else
				{
					TIM2->CCR3 = 0;
				}
				break;
			default:
				break;
		}
		usbCmd->updated = 0x00;
	}
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Configure the main internal regulator output voltage
  */
  __HAL_RCC_PWR_CLK_ENABLE();
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE2);
  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 25;
  RCC_OscInitStruct.PLL.PLLN = 336;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV4;
  RCC_OscInitStruct.PLL.PLLQ = 7;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK)
  {
    Error_Handler();
  }
  /** Enables the Clock Security System
  */
  HAL_RCC_EnableCSS();
}

/* USER CODE BEGIN 4 */
/**
 * @brief	Fungsi callback DMA UART
 * 			Dipanggil ketika DMA selesai menerima data dari AFE
 * 			AFE dan DSP berhubungan via USART1
 * @retval	Tidak ada
 *
 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef* huart)
{
	if((huart->Instance == USART1) && (isDataReady == 0))
	{
		// Konversi ADC ke tegangan (mV)
		for(int8_t i=0; i<8; i++)
		{
			DSP_ECGInputData[i] = (float)(AFE_ADCRawData[i]) * DSP_ADCToMillivoltScale;
		}
		isDataReady = 1;
	}
}

/**
 * @brief 	Fungsi callback TIM9
 * 			Aktif jika TIM9 diaktifkan, digunakan untuk timebase sampling
 * 			Ubah ARR untuk mengubah periode sampling
 * @retval  Tidak ada
 */
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef* htim)
{
	if(htim->Instance == TIM9)
	{
		// Aktifkan DMA Rx
		HAL_UART_Receive_DMA(&huart1, (uint8_t*)AFE_ADCRawData, 16);

		// Kirim command via DMA, supaya DSP tidak perlu menunggu proses kirim selesai
		afeCmd.command = (uint8_t)CMD_ADC;
		afeCmd.value = 0x0003;
		HAL_UART_Transmit_DMA(&huart1, (uint8_t*)&afeCmd, 4);
	}
}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

