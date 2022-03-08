/**
 * Library filter DSP untuk EKG STM32 (proyek skripsi)
 *
 * Oleh:
 * Reyhan Issatyadi Darmawan
 * Jurusan Fisika FMIPA Universitas Lampung
 * 2022
 */

#ifndef DSP_FILTER_H
#define DSP_FILTER_H

/**
 * Frekuensi sampling: 500 Hz
 *
 * Ada 4 filter yang disediakan di sini:
 * 1. Low-Pass Filter: 40 Hz, 75 Hz, 150 Hz(IIR orde 4)
 * 2. High-Pass Filter: off, 0.25 Hz, dan 0.5 Hz (FIR)
 * 3. Powerline Interference Filter 50 Hz
 * 4. ST filter 0.05 Hz
 *
 * Yang bisa ditambahkan ke depannya:
 * 1. Adaptive PLI filter
 * 2. EMG filter
 *
 * Urutan Filter DSP:
 * Input ----> ST Filter ---> HPF ----> LPF ----> PLI Filter ----> Output
 */

/**
 * ST FILTER 0.05 Hz
 */
const float STFilt_b0 =  0.9996859393;
const float STFilt_b1 = -0.9996859393;
const float STFilt_a1 = -0.9993718787;

typedef struct
{
	float x;
	float y;
	float w0;
	float w1;
	float b0;
	float b1;
	float a1;
} DSP_STFilter;


/*****************
 * HIGH PASS FILTER
 *
 * Filter diimplementasikan menggunakan IIR orde satu
 *****************/
const float HPF_b0_025Hz =  0.9984316659;
const float HPF_b1_025Hz = -0.9984316659;
const float HPF_a1_025Hz = -0.9968633318;
const float HPF_b0_050Hz =  0.9968682357;
const float HPF_b1_050Hz = -0.9968682357;
const float HPF_a1_050Hz = -0.9937364715;

typedef struct
{
	float x;
	float y;
	float w0;
	float w1;
	float b0;
	float b1;
	float a1;
	uint8_t isFilterOn;
} DSP_HighPassFilter;

/*****************
 * LOW PASS FILTER
 *
 * Filter diimplementasikan menggunakan biquad 2 section
 *****************/
/**
 * Koefisien filter LPF 40 Hz
 */
const float LPF_K_40Hz[2] = {
		0.0522195,	// Gain section 1
		0.0427980	// Gain section 2
};
const float LPF_a1_40Hz[3] = {
		1.00000000,	// a10, sebenarnya tidak digunakan
	   -1.47979889,	// a11
	    0.68867695	// a12
};
const float LPF_a2_40Hz[3] = {
		1.00000000,	// a20, sebenarnya tidak digunakan
	   -1.21281209,	// a21
	    0.38400416	// a22
};
/**
 * Koefisien filter LPF 75 Hz
 */
const float LPF_K_75Hz[2] = {
		0.1573822,	// Gain section 1
		0.1179485	// Gain section 2
};
const float LPF_a1_75Hz[3] = {
		1.00000000,	// a10, sebenarnya tidak digunakan
	   -0.89765794,	// a11
	    0.52718690	// a12
};
const float LPF_a2_75Hz[3] = {
		1.00000000,	// a20, sebenarnya tidak digunakan
	   -0.67274091,	// a21
	    0.14453519	// a22
};
/**
 * Koefisien filter LPF 150 Hz
 */
const float LPF_K_150Hz[2] = {
		0.4798612,	// Gain section 1
		0.3483908	// Gain section 2
};
const float LPF_a1_150Hz[3] = {
		1.00000000,	// a10, sebenarnya tidak digunakan
		0.45311952,	// a11
		0.46632557	// a12
};
const float LPF_a2_150Hz[3] = {
		1.00000000,	// a20, sebenarnya tidak digunakan
		0.32897567,	// a21
		0.06458765	// a22
};

/**
 * Implementasi LPF
 */
typedef struct
{
	// Input dan output
	float x;	// Input
	float y1;	// Output section 1
	float y2;	// Output section 2
	// Komponen section 1
	float K1;	// Gain
	float w10;
	float w11;
	float w12;
	float a11;	// a1
	float a12;	// a2
	// Komponen section 2
	float K2;	// Gain
	float w20;
	float w21;
	float w22;
	float a21;	// a1
	float a22;	// a2
} DSP_LowPassFilter;


/**
 * POWERLINE INTERFERENCE FILTER
 *
 * Menggunakan moving average
 */
typedef struct
{
	float DBuffer[32];
	float BBuffer[32];
	float Kf;
	float Df;
	float x;
	float y;
	uint8_t Ptr;
	uint8_t isFilterOn;
} DSP_PowerLineFilter;

#endif
