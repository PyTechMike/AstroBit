using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	public void LoadMainMenu () {
		SceneManager.LoadScene(0);
	}
	
	public void LoadDemoGame () {
		SceneManager.LoadScene(1);
	}
}
