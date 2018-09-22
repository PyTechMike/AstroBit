using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "wall") {
			other.gameObject.GetComponent<WallStandartController> ().bumped ();
		}
		if(other.gameObject.tag == "coin") {
			other.gameObject.GetComponent<CoinController> ().collected ();
		}
	}
}
