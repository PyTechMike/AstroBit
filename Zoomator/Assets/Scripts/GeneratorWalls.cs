﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWalls : MonoBehaviour {
	
	public GameObject wall;
	public GameObject longWall;

	public GameObject coin;

	private float[] nowAudioBands = new float[16];
	private float[] lastAudioBands = new float[16];
	private float plusBandDifference; 

	private bool canSpawn;

	public static float lastXPos = 1f;
	public static float lastYPos = 6f;
	public static int count;
	public float sensitivity;

	public static bool spawnWithLastPos = false;
	public static bool isFirstWall = true;

	IEnumerator WallGener() {
		yield return new WaitForSeconds(0.1f);

		for (int i = 0; i < 16; i++) {
			lastAudioBands[i] = nowAudioBands[i]; 

			nowAudioBands[i] = FirstAudioListener._audioBandBuffer[i];
		}

		if(canSpawn) { 
			// if(spawnWithLastPos) {
			// 	Instantiate(longWall);
			// }
			Instantiate(wall);	
			yield return new WaitForSeconds(0.05f);
			spawnWithLastPos = true;
		} else {
			spawnWithLastPos = false;
		}	
		StartCoroutine(WallGener());
		
	}

	void Start() {
		canSpawn = false;
		
		StartCoroutine(WallGener());
	}
	void Update() {
		for (int i = 0; i < 16; i++) {
			if(FirstAudioListener.middleAudioBandBuffer > 0.7f) {
				plusBandDifference = 1.3f + sensitivity;
			} else if(FirstAudioListener.middleAudioBandBuffer > 0.4f) {
				plusBandDifference = 1.3f + sensitivity;
			} else if(FirstAudioListener.middleAudioBandBuffer > 0.2f) {
				plusBandDifference = 1.3f + sensitivity;
			}
			if(lastAudioBands[i] > nowAudioBands[i] + sensitivity) {  
				canSpawn = true;	
			} else {
				canSpawn = false;
			}
		}
	}
}
