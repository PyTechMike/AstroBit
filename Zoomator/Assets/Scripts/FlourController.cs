using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourController : MonoBehaviour {
	private GameObject firstFlour;
	private GameObject player;

	void Start () {
		firstFlour = GameObject.Find ("firstFlour");
		player = GameObject.Find ("spaceship-v2"); //zoomer-middle
		
		transform.position = new Vector3 (firstFlour.transform.position.x, firstFlour.transform.position.y, firstFlour.transform.position.z + FlourGenerator.nowZPos); 	
	}

	void Update() { 
		if(player.transform.position.z > transform.position.z + 150) {
			Destroy (gameObject);
		}
	}

}
