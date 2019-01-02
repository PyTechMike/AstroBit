using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVis : MonoBehaviour {
	
	AudioSource audioSource;
	float[] _samples = new float[64];
	float[] _freqBand = new float[16];
	float[] _bandBuffer = new float[16];
	float[] _bufferDecrease = new float[16];

	float[] _freqBandHighest = new float[16];
	public static float[] _audioBand = new float[16];
	public static float[] _audioBandBuffer = new float[16];
	public static float middleAudioBandBuffer;
	
	private float _audioProfile = 0.0001f;	
	
	public float startDelay;
	private bool delay = false;

	IEnumerator PauseBeforeStart() {
		yield return new WaitForSeconds(startDelay + 1);
		audioSource.Play();
		delay = true;
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.Pause();

		AudioProfile(_audioProfile);

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

	void AudioProfile(float audioProfile) {
		for(int i = 0; i < 16; i++) {
			_freqBandHighest[i] = audioProfile; 
		}
	}

	void CreateAudioBands() {
		for(int i = 0; i < 16; i++) {
			if(_freqBand[i] > _freqBandHighest[i]) {
				_freqBandHighest[i] = _freqBand[i];
			}
			_audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
			for(int k = 0; k < 16; k++) {
				middleAudioBandBuffer += _audioBandBuffer[k];
			}
			middleAudioBandBuffer /= 16;  
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
