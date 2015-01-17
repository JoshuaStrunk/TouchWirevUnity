using UnityEngine;
using System.Collections;

public class LevelLoaderController : MonoBehaviour {

	public void loadLevel(int i) {
		Application.LoadLevel(i);
	}

	public void quitApp(){
		Application.Quit();
	}
}
