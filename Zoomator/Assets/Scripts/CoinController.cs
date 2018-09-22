using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	public bool autoPos;
	
	public float startPosX;
	public float startPosY;
	public float startPosZ;

	float endPosX;
	float endPosY;
	
	private bool destroied;

	private Vector3 destinationPoint;
	public float smoothing;

	private GameObject player;

	void Start() {
		destroied = false;
		player = GameObject.Find ("zoomer-middle");
		if(autoPos) {
			transform.position = new Vector3 (startPosX, startPosY, startPosZ + player.transform.position.z + 70);	
		}
		endPosX = Random.Range(-6f, 4f);
		endPosY = Random.Range(8f, 3.5f);
		destinationPoint = new Vector3(endPosX, endPosY, transform.position.z);
	}

	void Update () {
		smoothing = AudioVis.middleAudioBandBuffer + 0.3f;
		if (smoothing < 0.5f) {
			smoothing = 0.5f;
		}
		transform.position = Vector3.Lerp (transform.position, destinationPoint, smoothing * Time.deltaTime);
		if (transform.position.z < player.transform.position.z - 20) {
			if(!destroied) {
				Destroy (gameObject);
				destroied = true;
			}
		} 
			
	}

	public void collected() {
		if(!destroied) {
			Destroy (gameObject);
			destroied = true;
		}
	}
}
