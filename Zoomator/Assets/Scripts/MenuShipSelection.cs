using UnityEngine;
using UnityEngine.EventSystems;

public class MenuShipSelection : MonoBehaviour {
	public int ships;
	public GameObject shipsHolder;

	public void SelectLeftShip () {
		if(ApplicationModel.spaceShip > 1) {
			ApplicationModel.spaceShip -= 1;
			shipsHolder.GetComponent<ControllerShipsHolder>().MoveShipsHolder(15);
		}
	}	
	

	public void SelectRightShip () {
		if(ApplicationModel.spaceShip < ships) {
			ApplicationModel.spaceShip += 1;
			shipsHolder.GetComponent<ControllerShipsHolder>().MoveShipsHolder(-15);
		}
	}	
}
