using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour {

	public Transform leftPart;
	public Transform rightPart;
	private Vector3 leftPartPos;
	private Vector3 rightPartPos;
	private float averagePosX;
	private float averagePosY;

	public bool isTwoFingers;
	void Start () {
	}

	void Update () {
		if(isTwoFingers) {
			leftPartPos = leftPart.position;
			rightPartPos = rightPart.position;
			averagePosX = (leftPartPos.x + rightPartPos.x) / 2;
			averagePosY = (leftPartPos.y + rightPartPos.y) / 2;

			transform.position = new Vector3 (averagePosX, averagePosY, leftPartPos.z);

			transform.LookAt (leftPart);

			float dist = Vector3.Distance (leftPart.position, rightPart.position);

			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, dist + 1);
		}
	}
}
