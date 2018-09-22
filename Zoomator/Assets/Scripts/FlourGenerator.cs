using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourGenerator : MonoBehaviour {
	public GameObject flour;
	public float delay;
	public float ZPos;
	public static float nowZPos;

	IEnumerator CreateFlour() {
		yield return new WaitForSeconds(delay - AudioVis.middleAudioBandBuffer);
		Instantiate (flour);
		nowZPos += ZPos;
		StartCoroutine(CreateFlour());
		}

	void Start() {
		nowZPos = 0;
		StartCoroutine(CreateFlour());
	}
}

