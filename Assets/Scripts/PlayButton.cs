using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Text highscore;
    public void startGameAnt() {
        PlayerPrefs.SetInt("selChar", 0);
        SceneManager.LoadScene("GameScene");
    }

    public void startGameDoodle()
    {
        PlayerPrefs.SetInt("selChar", 1);
        SceneManager.LoadScene("GameScene");
    }

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Input.backButtonLeavesApp = true;
        highscore.text = "highscore: " + PlayerPrefs.GetFloat("highscore", 0).ToString();
    }
}
