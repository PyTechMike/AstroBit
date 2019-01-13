using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerShipsHolder : MonoBehaviour {

	public void MoveShipsHolder(float plusPositionX) {
		Vector3 tempPos = transform.position;
		tempPos.x += plusPositionX;
		transform.position = tempPos;
	}
}
