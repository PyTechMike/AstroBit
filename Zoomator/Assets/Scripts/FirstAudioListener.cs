using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FirstAudioListener : MonoBehaviour {

	AudioSource audioSource;
	float[] _samples = new float[64];
	float[] _freqBand = new float[16];
	float[] _bandBuffer = new float[16];
	float[] _bufferDecrease = new float[16];

	float[] _freqBandHighest = new float[16];
	public static float[] _audioBandBuffer = new float[16];
	
	public static float middleAudioBandBuffer;
	public static float FirstAudioBandBuffer;
	public static float SecondAudioBandBuffer;

	private bool delay = false;

	IEnumerator PauseBeforeStart() {
		yield return new WaitForSeconds(1);
		audioSource.Play();
		delay = true;
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();	
		audioSource.Pause();
		StartCoroutine(PauseBeforeStart());
	}

	void Update () {
		if (delay) {
			GetSpectrumAudioSource();
			MakeFrequencyBands();
			BandBuffer();
			CreateAudioBands();
		}
	}
	
	void CreateAudioBands() {
		for(int i = 0; i < 16; i++) {
			if(_freqBand[i] > _freqBandHighest[i]) {
				_freqBandHighest[i] = _freqBand[i];
			}
			_audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);

			for(int k = 0; k < 8; k++) {
				FirstAudioBandBuffer += _audioBandBuffer[k];
			}
			FirstAudioBandBuffer /= 8;
			for(int k = 8; k < 16; k++) {
				SecondAudioBandBuffer += _audioBandBuffer[k];
			}
			SecondAudioBandBuffer /= 8;  

			middleAudioBandBuffer = (FirstAudioBandBuffer + SecondAudioBandBuffer) / 2; 
		}
	}

	void GetSpectrumAudioSource() {
		audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
	}
	
	void BandBuffer() {
		for(int g = 0; g < 16; ++g) {
			if(_freqBand[g] > _bandBuffer[g]) {
				_bandBuffer[g] = _freqBand[g];
				_bufferDecrease[g] = 0.0000001f;
			}
			if(_freqBand[g] < _bandBuffer[g]) {
				_bandBuffer[g] -= _bufferDecrease[g];
				_bufferDecrease[g] *= 1.3f;
			}
		}
	}

	void MakeFrequencyBands() {
		int count = 0;

		for(int i = 0; i < 16; i++) {
			for(int j = 0; j < 4; j++) {
				_freqBand[i] += _samples[count + j];  
			}
			count += 4;
			_freqBand[i] = _freqBand[i] / 4;
		}

		count = 0;
	} 
}
