/**
 * @file main.cpp
 * @author REYHAN ISSATYADI DARMAWAN (reyhan.issatyadi1585@students.unila.ac.id)
 * @brief 
 * @version 1.0
 * @date 2022-02-06
 * 
 * @copyright Copyright (c) 2022
 * 
 * IMPLEMENTASI DARI AFE.h
 * Kontroler AFE  : ATMEGA328P-AU (SMD)
 * Frekuensi      : 16 MHz
 * Resolusi ADC   : 12-bit
 * Resolusi DAC   : 12-bit
 * Jumlah channel : 8
 * Antarmuka      : UART 1 Mbps
 */

#include <AFE.h>

MCP4725 dac(0x60);

// Konstruktor kelas
AFE::AFE()
{
    
}

// Destruktor kelas
// Sebenarnya untuk keperluan ini destruktor tidak diperlukan
// Tetapi di sini tetap ditambahkan untuk formalitas
AFE::~AFE()
{
    
}

void AFE::begin()
{
    // Inisialisasi LED
    ledOff();

    // Inisialisasi S/H
    hold();

    // Inisialisasi Multiplexer
    DDRD |= (1<<DDD5) | (1<<DDD4) | (1<<DDD3);
    disableMux();

    // Inisialisasi ADC
    FastGPIO::Pin<PIN_ADC_CS>::setOutputHigh();
    SPI.setDataMode(SPI_MODE3);
    SPI.setBitOrder(MSBFIRST);
    SPI.setClockDivider(SPI_CLOCK_DIV2);
    SPI.begin();

    // Inisialisasi DAC
    dac.begin();
    Wire.setClock(400000);
    dac.powerOnReset();
    dac.setValue(2047);
}

void AFE::setMuxChannel(uint8_t mux_ch)
{
    volatile uint8_t tmp1;

    // Baca register PORTD
    tmp1 = PORTD;

    // Clear bit 3, 4, dan 5
    tmp1 &= 0xC7;

    // Set bit 3, 4, dan 5
    tmp1 |= (mux_ch << 3);

    // kembalikan ke register PORTD
    PORTD = tmp1;
}

uint16_t AFE::readADC(uint8_t adc_ch)
{
    volatile uint16_t tmp2;

    // Aktifkan ADC
    FastGPIO::Pin<PIN_ADC_CS>::setOutputLow();

    // Kirim start bit
    SPI.transfer(0x01);

    // Kirim bit konfigurasi dan baca 4-bit pertama
    if(adc_ch == 0)
    {
        tmp2 = SPI.transfer(0xAF);
    }
    else if(adc_ch == 1)
    {
        tmp2 = SPI.transfer(0xEF);
    }
    else
    {
        return tmp2 = 0;
    }

    // Hilangkan null bit dan geser bit 8 langkah ke kiri
    tmp2 &= 0x0F;
    tmp2 <<= 8;

    // Baca 8-bit terakhir
    tmp2 |= SPI.transfer(0xFF);

    // Nonaktifkan ADC
    FastGPIO::Pin<PIN_ADC_CS>::setOutputHigh();

    return tmp2;
}

uint16_t AFE::writeDAC(uint16_t value)
{
    dac.setValue(value);

    return 0;
}