using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	public void ClickToRestart () {

		Application.LoadLevel (Application.loadedLevel) ;
	}
}
