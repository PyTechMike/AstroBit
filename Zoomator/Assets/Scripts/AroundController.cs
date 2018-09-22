using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundController : MonoBehaviour {

	private GameObject player;

	public float startPosX;
	public float startPosY;
	public float startPosZ;

	public float endPosY;
	private float destinationPosY;
	public float smoothing;

	void Start () {
		player = GameObject.Find ("spaceship-v2");

		transform.position = new Vector3 (startPosX, startPosY, startPosZ + player.transform.position.z);
	}
	
	void Update () {
		if(transform.position.z < player.transform.position.z) {
			Destroy (gameObject);
		}

		float destinationY = Mathf.Lerp(transform.position.y, endPosY, Time.deltaTime * smoothing);
		transform.position = new Vector3 (transform.position.x, destinationY, transform.position.z);
	}	
}