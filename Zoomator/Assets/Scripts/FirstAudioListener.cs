using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FirstAudioListener : MonoBehaviour {

	AudioSource audioSource;
	float[] _samples = new float[64];
	float[] _freqBand = new float[16];

	float[] _freqBandHighest = new float[16];
	public static float[] _audioBandBuffer = new float[16];
	
	public static float middleAudioBandBuffer;
	public static float FirstAudioBandBuffer;
	public static float SecondAudioBandBuffer;
	private float _audioProfile = 0.0001f;

	private bool delay = false;

	IEnumerator PauseBeforeStart() {
		yield return new WaitForSeconds(1);
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
			if(audioSource.isPlaying && menuButton.isPaused) {
				audioSource.Pause();
			} 
			if(!audioSource.isPlaying && !menuButton.isPaused) {
				audioSource.UnPause();
			} 
			GetSpectrumAudioSource();
			MakeFrequencyBands();
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
			_audioBandBuffer[i] = (_freqBand[i] / _freqBandHighest[i]);

			middleAudioBandBuffer += _audioBandBuffer[i];  
			middleAudioBandBuffer = middleAudioBandBuffer / 16; 
		}
	}

	void GetSpectrumAudioSource() {
		audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
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
