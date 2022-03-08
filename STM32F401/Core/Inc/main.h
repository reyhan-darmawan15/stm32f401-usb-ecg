/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.h
  * @brief          : Header for main.c file.
  *                   This file contains the common defines of the application.
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

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __MAIN_H
#define __MAIN_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_hal.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Exported types ------------------------------------------------------------*/
/* USER CODE BEGIN ET */
/**
 * @brief Struktur command yang diterima via USB
 * Untuk mengubah pengaturan DSP
 *
 * Untuk memudahkan development, kita gunakan protokol yang sama dengan ATMEGA328
 * Tetapi berbeda awalan dan nilai...
 * Kemudian ada 1 byte tambahan yang menyatakan apakah ada perubahan pengaturan atau tidak,
 * sehingga DSP tahu kapan harus mengupdate pengaturan
 *
 * ----------------------------------------------------------------
 * Command       Value      ACK     Keterangan
 * ----------------------------------------------------------------
 * G             0x0000     0x06    Set gain ke 5 mm/mV
 *               0x0001				Set gain ke 10 mm/mV
 *               0x0002             Set gain ke 20 mm/mV
 * ----------------------------------------------------------------
 * H             0x0000     0x06    Nonaktifkan HPF
 *               0x0001             Set HPF ke 0.25 Hz
 *               0x0002             Set HPF ke 0.50 Hz
 * ----------------------------------------------------------------
 * L             0x0000     0x06    Set LPF ke 40 Hz
 * 				 0x0001				Set LPF ke 75 Hz
 * 				 0x0002				Set LPF ke 150 Hz
 * ----------------------------------------------------------------
 * P             0x0000     0x06    Nonaktifkan powerline filter
 *               0x0001             Aktifkan powerline filter
 * ----------------------------------------------------------------
 * D			 0x0000     0x06    Nonaktifkan PWM DAC
 *               0x0001     		Output R-F ke PWM DAC
 *               0x0002				Output L-F ke PWM DAC
 *               0x0003             Output C1-F ke PWM DAC
 *               ...
 *               0x0008				Output C6-F ke PWM DAC
 * (Fitur ini digunakan untuk testing)
 * ----------------------------------------------------------------
 * R             4999-      0x06	Set laju kedip LED hijau
 * 				  279				(4999 = 24 bpm, 331 = 360 bpm)
 * 				    0               Matikan LED
 * ----------------------------------------------------------------
 * @param command: Command dari PC, 1-byte
 * @param value	 : Nilai parameter command, 2-byte
 * @param ack	 : ACK, selalu bernilai 0x06 untuk saat ini dan dapat diabaikan
 * @param updated: Menandakan ke DSP jika ada perubahan pengaturan
 */
typedef struct __attribute__((__packed__))
{
	uint8_t command;
	uint16_t value;
	uint8_t ack;
	uint8_t updated;
} DSP_UsbCommandReqTypeDef;
DSP_UsbCommandReqTypeDef* usbCmd;

/**
 * @brief Struktur command kontrol AFE (ATMEGA328)
 * Untuk mengontrol analog front-end (AFE)
 *
 * Untuk memudahkan development, kita gunakan protokol yang sama dengan ATMEGA328
 *
 * ----------------------------------------------------------------
 * Command       Value      ACK     Keterangan
 * ----------------------------------------------------------------
 * L             0x0000     0x06    LED orange off
 *               0x0001				LED orange on
 * ----------------------------------------------------------------
 * C             0x0000     0x06    Set mux CH0
 *               ...
 *               0x0007             Set mux CH7
 * ----------------------------------------------------------------
 * S*            0x0000     0x06    S/H Hold
 * 				 0x0001				S/H Sample
 * ----------------------------------------------------------------
 * A             don't      0x06    Baca ADC1 dan ADC2
 *               care
 * ----------------------------------------------------------------
 * D			 0x0000 (0) 0x06	Set output DAC AFE
 * 				 ...
 * 				 0x0FFF (4095)
 * ----------------------------------------------------------------
 * B			 0x0000 (0) 0x06	Gabungan command A dan D
 * 				 ...				(Set DAC dan baca ADC1 ADC2)
 * 				 0x0FFF (4095)
 * ----------------------------------------------------------------
 * *) Karena kesalahan desain, maka S/H dibypass untuk saat ini
 *
 * @param command: Command dari PC, 1-byte
 * @param value	 : Nilai parameter command, 2-byte
 * @param ack	 : ACK, selalu bernilai 0x06 untuk saat ini dan dapat diabaikan
 * @param updated: Menandakan ke DSP jika ada perubahan pengaturan
 */
typedef struct __attribute__((__packed__))
{
	uint8_t command;
	uint16_t value;
	uint8_t ack;
} DSP_AFECommandTypeDef;
DSP_AFECommandTypeDef afeCmd;

/* USER CODE END ET */

/* Exported constants --------------------------------------------------------*/
/* USER CODE BEGIN EC */

/* USER CODE END EC */

/* Exported macro ------------------------------------------------------------*/
/* USER CODE BEGIN EM */

/* USER CODE END EM */

/* Exported functions prototypes ---------------------------------------------*/
void Error_Handler(void);

/* USER CODE BEGIN EFP */

/* USER CODE END EFP */

/* Private defines -----------------------------------------------------------*/
#define PWR_PWM_A_Pin GPIO_PIN_7
#define PWR_PWM_A_GPIO_Port GPIOA
#define ECG_PWM_OUT_Pin GPIO_PIN_0
#define ECG_PWM_OUT_GPIO_Port GPIOB
#define LED_GREEN_Pin GPIO_PIN_10
#define LED_GREEN_GPIO_Port GPIOB
#define PWR_PWM_B_Pin GPIO_PIN_8
#define PWR_PWM_B_GPIO_Port GPIOA
/* USER CODE BEGIN Private defines */

/* USER CODE END Private defines */

#ifdef __cplusplus
}
#endif

#endif /* __MAIN_H */
