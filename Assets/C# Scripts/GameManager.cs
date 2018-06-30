using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Image image;
    public int lvl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(image,1);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(lvl);
        }
    }

    public void changeToScene(int toScene)
    {
        SceneManager.LoadScene(toScene);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
