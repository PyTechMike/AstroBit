using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShipMainMenu : MonoBehaviour {

	private float needToRotateY;
	public float plusRotationY;

	void Start () {
		needToRotateY = plusRotationY;
	}
	
	void Update () { 
		if(needToRotateY == 360) {
			needToRotateY = 0;
		} 
		transform.rotation = Quaternion.Euler(270, 0, needToRotateY);
		needToRotateY += plusRotationY;
	}
}
