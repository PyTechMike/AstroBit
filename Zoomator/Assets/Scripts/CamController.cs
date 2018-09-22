using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CamController : MonoBehaviour {

	public GameObject player;

	public float differenceZ;
	public float differenceY;
	public float smoothing;

	private Vector3 destinationPoint;

	void Update () {
		// destinationPoint = new Vector3 (player.transform.position.x, player.transform.position.y + differenceY, player.transform.position.z - differenceZ);
		// transform.position = Vector3.Lerp(transform.position, destinationPoint, Time.deltaTime * 1f);
		float destinationX = Mathf.Lerp(transform.position.x, player.transform.position.x, Time.deltaTime * smoothing);
		float destinationY = Mathf.Lerp(transform.position.y, player.transform.position.y + differenceY, Time.deltaTime * smoothing);
		transform.position = new Vector3(destinationX, destinationY, player.transform.position.z - differenceZ);
		if(AudioVis.middleAudioBandBuffer > 0.2f) {
			CameraShaker.Instance.ShakeOnce(AudioVis.middleAudioBandBuffer, 3f, 0.1f, 1f);
		} 
		if(AudioVis.middleAudioBandBuffer > 0.4f) {
			CameraShaker.Instance.ShakeOnce(AudioVis.middleAudioBandBuffer + 0.5f, 3f, 0.1f, 1f);
		} 
		if(AudioVis.middleAudioBandBuffer > 0.6f) {
			CameraShaker.Instance.ShakeOnce(AudioVis.middleAudioBandBuffer + 1f, 3f, 0.1f, 1f);
		}
	}
}
