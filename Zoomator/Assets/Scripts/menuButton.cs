using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButton : MonoBehaviour {

	public static bool isPaused;

	void Start() {
		isPaused = false;
	}

	public void stopGame () {
		if(Time.timeScale == 1) {
			Time.timeScale = 0;
			isPaused = true;
		} else
		{
			Time.timeScale = 1;
			isPaused = false;
		}
	}
}
