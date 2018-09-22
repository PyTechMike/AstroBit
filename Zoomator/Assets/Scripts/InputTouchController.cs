using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchController : MonoBehaviour {

	public TouchPadController touchPad;

	public GameObject anotherPart;

	// public bool isFirstTouch = false;

	private bool TouchPadTouched;
	public bool left;
	public bool right; 

	private bool canFollow;
	private int needTouch; 

	public bool isTwoFingers;
	void Start () {
		canFollow = false;
	}

	void Update () {
		if(isTwoFingers) {
			if (Input.touchCount > 0) {
				if(left) {
					if (Input.GetTouch(0).position.x < (Screen.width/2)) {
						if (Input.GetTouch(0).phase == TouchPhase.Began) {
							canFollow = true;
							needTouch = 0;
						}
					}
					if (Input.GetTouch(1).position.x < (Screen.width/2)) {
						if (Input.GetTouch(1).phase == TouchPhase.Began) {
							canFollow = true;
							needTouch = 1;
						}
					}
				}

				if(right) {
					if (Input.GetTouch(0).position.x > (Screen.width/2)) {
						if (Input.GetTouch(0).phase == TouchPhase.Began) {
							canFollow = true;
							needTouch = 0;
						}
					}
					if (Input.GetTouch(1).position.x > (Screen.width/2)) {
						if (Input.GetTouch(1).phase == TouchPhase.Began) {
							canFollow = true;
							needTouch = 1;
						}
					}
				}
				if (Input.GetTouch(needTouch).phase == TouchPhase.Ended) {
					canFollow = false;
				}

				if(canFollow) {
					transform.Translate (Input.GetTouch(needTouch).deltaPosition * Time.deltaTime * 1f);
				}
			}
		} else {
			if (Input.touchCount > 0) {
				if (Input.GetTouch(0).phase == TouchPhase.Began) {
					canFollow = true;
				}
				if (Input.GetTouch(0).phase == TouchPhase.Ended) {
					// canFollow = false;
				}
				if(canFollow) {
					transform.Translate (Input.GetTouch(0).deltaPosition * Time.deltaTime * 1f);
				}
			}
		} 
	}
}
