using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text lastscore;
    public Text highscore;

    public AudioSource highscoreSound;
    public void reStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        float highScoreNum = PlayerPrefs.GetFloat("highscore", 0);
        float lastScore = PlayerPrefs.GetFloat("lastScore", 0);
        if (highScoreNum >0 && highScoreNum == lastScore && highscoreSound != null)
        {
            highscoreSound.Play();
        }
        highscore.text = "Highscore: " + highScoreNum.ToString();
        lastscore.text = "Score: " + lastScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
