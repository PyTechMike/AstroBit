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
		if(transform.position.z < player.transform.position.z) {
			transform.position = new Vector3 (0, 28, player.transform.position.z + 70);
		}
		
		if(FirstAudioListener.middleAudioBandBuffer * 0.3f > 0.2f) {
			somePlusSpeed = 0.2f;
		} else {
			somePlusSpeed = FirstAudioListener.middleAudioBandBuffer * 0.3f;
		}
		readySpeed = defaultSpeed + (FirstAudioListener.middleAudioBandBuffer * plusSpeed) + FirstAudioListener.middleAudioBandBuffer *  (1.8f + somePlusSpeed);
		
		transform.Translate (direction * readySpeed * Time.deltaTime);	
	}
}
