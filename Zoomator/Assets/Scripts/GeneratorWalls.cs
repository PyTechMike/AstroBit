using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWalls : MonoBehaviour {
	
	public GameObject wall;
	public GameObject coin;

	private float[] FirstAudioBand = new float[2];
	private float[] SecondAudioBand = new float[2];
	public float delay;
	private bool canSpawn;

	public static float lastXPos = 1f;
	public static float lastYPos = 6f;

	public static int count;

	public static bool spawnWithLastPos = false;

	public static bool isFirstWall = true;

	IEnumerator WallGener() {
		yield return new WaitForSeconds(0.1f);
		
		FirstAudioBand[1] = FirstAudioBand[0];
		FirstAudioBand[0] = FirstAudioListener.FirstAudioBandBuffer; 
		
		SecondAudioBand[1] = SecondAudioBand[0];
		SecondAudioBand[0] = FirstAudioListener.SecondAudioBandBuffer; 
		
		if(canSpawn) {  
			Instantiate (wall);	
			yield return new WaitForSeconds(0.05f);
			spawnWithLastPos = true;
		} else {
			spawnWithLastPos = false;
		}	
		StartCoroutine(WallGener());
		
	}

	void Start() {
		FirstAudioBand[0] = 0;
		FirstAudioBand[1] = 0;

		SecondAudioBand[0] = 0;
		SecondAudioBand[1] = 0;

		canSpawn = false;
		
		StartCoroutine(WallGener());
	}
	void Update() {
		if(FirstAudioListener.middleAudioBandBuffer > 0.7f) {
			if(FirstAudioBand[0] > FirstAudioBand[1] + 0.1f || SecondAudioBand[0] > SecondAudioBand[1] + 0.1f) {  
				canSpawn = true;	
			} else {
				canSpawn = false;
			}
		} else if(FirstAudioListener.middleAudioBandBuffer > 0.3f) {
			if(FirstAudioBand[0] > FirstAudioBand[1] + 0.12f || SecondAudioBand[0] > SecondAudioBand[1] + 0.12f) {  
				canSpawn = true;	
			} else {
				canSpawn = false;
			}
		} else if(FirstAudioListener.middleAudioBandBuffer > 0.2f) {
			if(FirstAudioBand[0] > FirstAudioBand[1] + 0.08f || SecondAudioBand[0] > SecondAudioBand[1] + 0.08f) {  
				canSpawn = true;	
			} else {
				canSpawn = false;
			}
		} else {
			if(FirstAudioBand[0] > FirstAudioBand[1] + 0.03f || SecondAudioBand[0] > SecondAudioBand[1] + 0.03f) {  
				canSpawn = true;	
			} else {
				canSpawn = false;
			}
		}
	}
}
