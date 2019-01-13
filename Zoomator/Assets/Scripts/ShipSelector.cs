using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour {
	
	public GameObject spaceShip1;
	public GameObject spaceShip2;

	void Start () {
		if(ApplicationModel.spaceShip == 1) {
			spaceShip2.GetComponent<PlayerGoController>().DestroyShip();
		}	else if (ApplicationModel.spaceShip == 2) {
			spaceShip1.GetComponent<PlayerGoController>().DestroyShip();
		}
	}
}
