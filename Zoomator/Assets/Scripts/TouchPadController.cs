using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchPadController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler{

	public bool touched;

	public void OnPointerDown( PointerEventData eventData ) {
		touched = true;
	}

	public void OnDrag( PointerEventData eventData ) {
		touched = true;
	}

	public void OnPointerUp( PointerEventData eventData ) {
		touched = false;
	}

	public bool getTouch() {
		return touched = true;
	}

}
