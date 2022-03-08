/**
 * @file main.cpp
 * @author REYHAN ISSATYADI DARMAWAN (reyhan.issatyadi1585@students.unila.ac.id)
 * @brief 
 * @version 1.0
 * @date 2022-02-06
 * 
 * @copyright Copyright (c) 2022
 * 
 * FIRMWARE ANALOG FRONT-END (AFE) EKG 12 LEAD BERBASIS STM32F401
 * Kontroler AFE  : ATMEGA328P-AU (SMD)
 * Frekuensi      : 16 MHz
 * Resolusi ADC   : 12-bit
 * Resolusi DAC   : 12-bit
 * Jumlah channel : 8
 * Antarmuka      : UART 1 Mbps
 */

#include <Arduino.h>
#include <AFE.h>
#include <util/delay.h>

typedef struct __attribute__((__packed__))
{
  uint8_t command;
  uint16_t value;
  uint8_t ack;
}
AFECommand_StructTypeDef;

uint8_t cmdReceived = 0;
uint8_t cmdRxBuffer[4];
AFECommand_StructTypeDef* cmd;
AFE ecg;

#pragma GCC push_options
#pragma GCC optimize ("O3")

volatile static uint16_t adc1, adc2;
volatile static uint16_t adcArray[8];
volatile static uint16_t dac[8] = {
  2047,
  2047,
  2047,
  2047,
  2047,
  2047,
  2047,
  2047
};
volatile static uint8_t channelOrder[8] = {
  5, 4, 0, 6, 7, 2, 1, 3
};

void setup()  
{
  // put your setup code here, to run once:

  ecg.begin();
  ecg.disableMux();
  ecg.hold();

  cmd = (AFECommand_StructTypeDef*)cmdRxBuffer;

  // Aktifkan Serial
  Serial.begin(1000000, SERIAL_8N2);  // Gunakan 250000 untuk testing, 1000000 untuk keperluan normal
  Serial.setTimeout(10);
}

void loop()  
{
  // put your main code here, to run repeatedly:

  uint16_t val = 0;
  if((Serial.readBytes(cmdRxBuffer, 4) != 0) && (cmdReceived == 0))
  {
    cmdReceived = 1;
  }

  if(cmdReceived == 1)
  {
    switch (cmd->command)
    {
      case 'L':
        // Command untuk LED orange
        if(cmd->value == 0x0001) ecg.ledOn();
        if(cmd->value == 0x0000) ecg.ledOff();
        break;
      case 'C':
        // Command untuk set channel multiplexer
        ecg.ledOn();
        ecg.setMuxChannel((uint8_t)cmd->value);
        ecg.ledOff();
        break;
      case 'S':
        // Command sample-and-hold
        ecg.ledOn();
        if(cmd->value == 0x0000) ecg.hold();
        if(cmd->value == 0x0001) ecg.sample();
        ecg.ledOff();
        break;
      case 'A':
        // Command untuk baca nilai ADC
        if(cmd->value == 0x0001)  // ADC1 single channel
        {
          ecg.ledOn();
          ecg.enableMux();
          adc1 = ecg.readADC(0);
          Serial.write((uint8_t*)&adc1, 2);
          ecg.disableMux();
          ecg.ledOff();
        }
        if(cmd->value == 0x0002) // ADC2 single channel
        {
          ecg.ledOn();
          ecg.enableMux();
          adc1 = ecg.readADC(0);
          Serial.write((uint8_t*)&adc1, 2);
          ecg.disableMux();
          ecg.ledOff();
        }
        if(cmd->value == 0x0003)  // ADC2 all channel + DAC
        {
          ecg.ledOn();
          ecg.sample();
          ecg.enableMux();
          for(int8_t i=0; i<8; i++)
          {
            ecg.setMuxChannel(channelOrder[i]);

            ecg.writeDAC(dac[i]);

            adc2 = ecg.readADC(1);

            adcArray[i] = 0;
            if(adc2 > 2867) // ADC2 > 3.5 V
            {
              dac[i] += 1;
              if(dac[i] > 4095) dac[i] = 4095;
              for(int8_t j=0; j<8; j++)
              {
                adcArray[i] += (ecg.readADC(1) + 128);
              }
            }
            else if(adc2 < 1228) // ADC2 < 1.5 V
            {
              dac[i] -= 1;
              if(dac[i] < 1) dac[i] = 0;
              for(int8_t j=0; j<8; j++)
              {
                adcArray[i] += (ecg.readADC(1) - 128);
              }
            }
            else
            {
              for(int8_t j=0; j<8; j++)
              {
                adcArray[i] += ecg.readADC(1);
              }
            }
            adcArray[i] >>= 1;
          }
          Serial.write((uint8_t*)adcArray, 16);
          ecg.disableMux();
          ecg.ledOff();
        }
        break;
      case 'B':
        // Command untuk update DAC dan baca nilai ADC sekaligus
        ecg.ledOn();
        ecg.enableMux();
        ecg.writeDAC(cmd->value);
        adc1 = ecg.readADC(0);
        adc2 = ecg.readADC(1);
        Serial.write((uint8_t*)&adc1, 2);
        Serial.write((uint8_t*)&adc2, 2);
        ecg.disableMux();
        ecg.ledOff();
        break;
      case 'D':
        // Command untuk set output DAC
        ecg.ledOn();
        ecg.writeDAC(cmd->value);
        ecg.ledOff();
        break;
      default:
        break;
    }

    // Akhiri proses dan tunggu perintah berikutnya
    cmdReceived = 0;
  }
}

void serialEvent() 
{
  // Simpan data di buffer
  
}
#pragma GCC pop_options