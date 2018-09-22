using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	private float startPos;

	private float endPosMinX;
	private float endPosMaxX;

	public float plusPos;

	void Start () {
		startPos = transform.position.x - 0.47f;
		endPosMaxX = startPos + plusPos;
		endPosMinX = startPos - plusPos;
	}
	
	void Update () {
		SetAngle();
		CheckPos();
	}

	void SetAngle() {
		if(transform.position.x > startPos) {
				float needTurn = transform.position.x / endPosMaxX;
				transform.rotation = Quaternion.Euler(0, 0, 30 * needTurn);
		}
		if(transform.position.x < startPos) {
				float needTurn = transform.position.x / endPosMinX;
				transform.rotation = Quaternion.Euler(0, 0, -30 * needTurn);
		}
	}

	void CheckPos() {
		if(transform.position.x > endPosMaxX + 0.4f) {
			transform.position = new Vector3 (endPosMaxX + 0.4f, transform.position.y, transform.position.z);		
		}
		if(transform.position.x < endPosMinX) {
			transform.position = new Vector3 (endPosMinX, transform.position.y, transform.position.z);		
		}
		if(transform.position.y > 7f) { //7.7
			transform.position = new Vector3 (transform.position.x, 7f, transform.position.z);		
		}
		if(transform.position.y < 3f) { // 2
			transform.position = new Vector3 (transform.position.x, 3f, transform.position.z);		
		}
	}
}
