/**
 * @file main.cpp
 * @author REYHAN ISSATYADI DARMAWAN (reyhan.issatyadi1585@students.unila.ac.id)
 * @brief 
 * @version 1.0
 * @date 2022-02-06
 * 
 * @copyright Copyright (c) 2022
 * 
 * LIBRARY ANALOG FRONT-END (AFE) EKG 12 LEAD BERBASIS STM32F401
 * Kontroler AFE  : ATMEGA328P-AU (SMD)
 * Frekuensi      : 16 MHz
 * Resolusi ADC   : 12-bit
 * Resolusi DAC   : 12-bit
 * Jumlah channel : 8
 * Antarmuka      : UART 1 Mbps
 */

#ifndef AFE_H
#define AFE_H

#include <Arduino.h>
#include <MCP4725.h>
#include <SPI.h>
#include <FastGPIO.h>

#define PIN_MUX_EN  IO_D7
#define PIN_ADC_CS  IO_B0
#define PIN_SH_CTRL IO_B1
#define PIN_LED     IO_B2

// Implementasi kelas AFE
class AFE
{
    private:

    public:
        AFE();
        ~AFE();
        void begin();
        void sample();
        void hold();
        void enableMux();
        void disableMux();
        void ledOn();
        void ledOff();
        void setMuxChannel(uint8_t mux_ch);
        uint16_t readADC(uint8_t adc_ch);
        uint16_t writeDAC(uint16_t value);
};

inline void AFE::disableMux()
{
    FastGPIO::Pin<PIN_MUX_EN>::setOutputHigh();
}

inline void AFE::enableMux()
{
    FastGPIO::Pin<PIN_MUX_EN>::setOutputLow();
}

inline void AFE::sample()
{
    FastGPIO::Pin<PIN_SH_CTRL>::setOutputHigh();
}

inline void AFE::hold()
{
    FastGPIO::Pin<PIN_SH_CTRL>::setOutputLow();
}

inline void AFE::ledOff()
{
    FastGPIO::Pin<PIN_LED>::setOutputLow();
}
inline void AFE::ledOn()
{
    FastGPIO::Pin<PIN_LED>::setOutputHigh();
}

#endif