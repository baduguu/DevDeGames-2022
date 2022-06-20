using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreTXT;
    
    public AudioSource playSound;
    public AudioSource quitSound;

    // Start is called before the first frame update
    void Start()
    {
        highscoreTXT.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        playSound.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        quitSound.Play();
        Application.Quit();
    }    
}
