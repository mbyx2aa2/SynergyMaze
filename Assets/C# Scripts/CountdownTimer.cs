using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {
    Image timerBar;
    public int levelToLoad;
    public float maxTime = 0;
    float timeLeft;
	// Use this for initialization
	void Start () {
        timeLeft = maxTime;
        timerBar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }

        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
	}
}
