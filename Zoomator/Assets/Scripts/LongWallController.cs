﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;
using System;

public class LongWallController : MonoBehaviour {
public bool autoPos;
	
	public float startPosX;
	public float startPosY;
	public float startPosZ;

	float endPosX;
	float endPosY;
	
	private bool destroied;

	private Vector3 destinationPoint;
	public float smoothing;
	private float plusSpeed;

	public int numberInRow;
	public bool isFirstWall;

	private GameObject player;
	private GameObject generator;

	private Text wallTime;

	Stopwatch stopWatch = new Stopwatch();
	void Start() {
        stopWatch.Start();
        
		destroied = false;
		player = GameObject.Find ("spaceship-v2");
		generator = GameObject.Find ("wallGenerator");
		wallTime = GameObject.Find("WallTimer").GetComponent<Text> ();
		
		if(autoPos) {
			plusSpeed = 0;
			transform.position = new Vector3 (startPosX, startPosY, (startPosZ + player.transform.position.z + 70 + plusSpeed) - (1.16f * numberInRow));
			
			// if(FirstAudioListener.middleAudioBandBuffer < 0) {
			// 	plusSpeed = 0;
			// } else {
			// 	plusSpeed = 60 * FirstAudioListener.middleAudioBandBuffer;
			// }
			// transform.position = new Vector3 (startPosX, startPosY, startPosZ + generator.transform.position.z);	
		}

		endPosX = GeneratorWalls.lastXPos;
		endPosY = GeneratorWalls.lastYPos; 
		
		destinationPoint = new Vector3(endPosX, endPosY, transform.position.z);

		GeneratorWalls.lastXPos = endPosX;
		GeneratorWalls.lastYPos = endPosY;
	}

	void Update () {
		smoothing = AudioVis.middleAudioBandBuffer + 1.7f;
		if (smoothing < 2f) {
			smoothing = 2f;
		}
		transform.position = Vector3.Lerp (transform.position, destinationPoint, smoothing * Time.deltaTime);
		if (transform.position.z < player.transform.position.z) {
			if(!destroied) {
				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;

				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					ts.Hours, ts.Minutes, ts.Seconds,
					ts.Milliseconds / 10);
				// wallTime.text = elapsedTime;

				Destroy (gameObject);
				destroied = true;

				if(player.transform.position.x < transform.position.x + 2 && player.transform.position.x > transform.position.x - 3) {
					if(isFirstWall) {
						GeneratorWalls.count += 1;
						wallTime.text = GeneratorWalls.count.ToString();
						Vibration.Vibrate(40);
					}
				}
			}
		} 
		// UnityEngine.Debug.Log(FirstAudioListener.middleAudioBandBuffer);
			
	}

	public void bumped() {
		if(!destroied) {
			stopWatch.Stop();

			TimeSpan ts = stopWatch.Elapsed;

			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds / 10);
			// wallTime.text = elapsedTime;

			Destroy (gameObject);
			destroied = true;

			if(isFirstWall) {
				if(GeneratorWalls.count != 0) {
					GeneratorWalls.count -= 1;
				}
			}
			wallTime.text = GeneratorWalls.count.ToString();
				
		}
	}
}
