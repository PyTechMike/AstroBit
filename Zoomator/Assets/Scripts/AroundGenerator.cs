using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundGenerator : MonoBehaviour {

	public GameObject aroundItem;

	IEnumerator AroundGener() {
		yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
		Instantiate (aroundItem);	
		StartCoroutine(AroundGener());
		
	}
	void Start () {
		StartCoroutine(AroundGener());	
	}
}
