using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoController : MonoBehaviour {

	public float defaultSpeed;
	public float plusSpeed;
	private float readySpeed; 
	public Vector3 direction;
	
	public bool isOnComing;
	public float plusPos = 48f;
	public float scale = 20f;

	private float musicVolume;

	void Start () {
	}

	void Update () {
		musicVolume = AudioVis.middleAudioBandBuffer;
		if(isOnComing) {
			GameObject player = GameObject.Find("spaceship-v2"); //zoomer-middle
			transform.position = new Vector3 (transform.position.x, transform.position.y, player.transform.position.z + plusPos - musicVolume * scale);
		} else {

			readySpeed = defaultSpeed + (musicVolume * plusSpeed);

			transform.Translate (direction * readySpeed * Time.deltaTime);		
		}
	}
}
