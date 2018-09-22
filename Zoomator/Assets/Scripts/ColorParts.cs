using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorParts : MonoBehaviour {

	public bool redColor;
	public bool blueColor;
	public bool greenColor;
	public bool greyColor;
	private Color colorObj;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(redColor) {
			colorObj = Color.red;
		} else if(blueColor) {
			colorObj = Color.blue;
		} else if(greenColor) {
			colorObj = Color.green;
		} else if(greyColor) {
			colorObj = Color.grey;
		}

		gameObject.GetComponent<Renderer> ().material.color = colorObj;
	}

	public void setGreen(GameObject other) {
		other.GetComponent<Renderer> ().material.color = Color.green;
	}

	public void setRed(GameObject other) {
		other.GetComponent<Renderer> ().material.color = Color.red;
	}
}
