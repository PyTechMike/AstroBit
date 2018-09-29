using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneratorGoController : MonoBehaviour {

	public float defaultSpeed;
	public float plusSpeed;
	private float somePlusSpeed;
	private float readySpeed; 
	public Vector3 direction;
	private GameObject player;

	void Start () {
		player = GameObject.Find ("spaceship-v2");
		transform.position = new Vector3 (0, 28, player.transform.position.z + 70);		
	}
	
	void Update () {
		if(FirstAudioListener.middleAudioBandBuffer < 0) {
			readySpeed = defaultSpeed;
		} else {
			readySpeed = defaultSpeed + (FirstAudioListener.middleAudioBandBuffer * plusSpeed);
		}
		// if(FirstAudioListener.middleAudioBandBuffer * 0.3f > 0.2f) {
		// 	somePlusSpeed = 0.2f;
		// } else {
		// 	somePlusSpeed = FirstAudioListener.middleAudioBandBuffer * 0.3f;
		// }
		
		transform.Translate (direction * readySpeed * Time.deltaTime);	
	}
}
