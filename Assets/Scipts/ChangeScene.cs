using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {


	public void StartGame(string sceneName){

		Application.LoadLevel (sceneName);
	}
}
