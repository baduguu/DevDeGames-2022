using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;

    public GameObject gameoverScreen;

    public Text scoreTXT;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        gameoverScreen.SetActive(false);
        Time.timeScale = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameoverScreen.SetActive(true);
            Time.timeScale = 0;   
        }
        else
        {
            scoreTXT.text = "SCORE: " + (int)score;
            
            if((int)score > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", (int)score);
            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainScene");
        
    }
}
