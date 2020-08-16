using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text highscoreText;
    // private int highscore;
    public Text scoreText;
    private int score = 0;
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    // Start is called before the first frame update

    void Start(){
        highscoreText.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(gameOver == true && Input.GetMouseButtonDown (0))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
        // }
    }
    public void BirdieScored()
    {
        if(gameOver)
        {
            return;
        }
        score ++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdieDie()
    {
        if (PlayerPrefs.GetFloat("Highscore") <= score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }

        gameOverText.SetActive (true);
        gameOver = true;
    }
}
