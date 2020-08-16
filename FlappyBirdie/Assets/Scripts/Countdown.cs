using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    private float time = 3;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
            else
            {
                SceneManager.LoadScene(2);
                time = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay +=1;
        countdownText.text = "Ready: " + ((int)timeToDisplay).ToString();
    }
}
