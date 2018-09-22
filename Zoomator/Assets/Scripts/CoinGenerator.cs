using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public GameObject coin;
	// public GameObject wall1;
	// public GameObject wall2;
	public float delay;

	IEnumerator waitBeforeStart() {
		yield return new WaitForSeconds(1f);
	}
	IEnumerator CoinGener() {
		yield return new WaitForSeconds(delay - AudioVis.middleAudioBandBuffer);
		if(AudioVis.middleAudioBandBuffer > 0.5f) {
			Instantiate (coin);
			Instantiate (coin);
		} else {
			Instantiate (coin);
		}
		StartCoroutine(CoinGener());
		// if (Random.Range (0, 2) == 0) {
		// 	Instantiate (wall1);	
		// } else {
		// 	Instantiate (wall2);
		// }
	}

	void Start() {
		StartCoroutine(waitBeforeStart());
		StartCoroutine(CoinGener());
	}
}
