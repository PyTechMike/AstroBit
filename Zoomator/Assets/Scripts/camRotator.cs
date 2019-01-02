using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotator : MonoBehaviour {

	public GameObject player;
	
	public float smoothing;

	private float rotationZ;

	void Update () {
		float rotationZ = Mathf.Lerp(transform.rotation.z, player.transform.rotation.z, Time.deltaTime * smoothing);

		transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationZ);
	}
}
