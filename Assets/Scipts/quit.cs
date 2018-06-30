using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	public void exit(){
		Debug.Log("you quit the game");
		Application.Quit ();
	}
}
