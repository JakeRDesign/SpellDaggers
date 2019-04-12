using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsManager : MonoBehaviour {

    public float playerScore;
    public float highScore;

    public Button menuButton;
    public Button restartButton;

    public GameObject scoreText;
    public GameObject highscoreText;

    void Start () {
        menuButton.GetComponent<Button>().onClick.AddListener(PressMenu);
        restartButton.GetComponent<Button>().onClick.AddListener(PressRestart);

        playerScore = PlayerPrefs.GetFloat("score");
        highScore = PlayerPrefs.GetFloat("highscore" + PlayerPrefs.GetFloat("difficulty"));

        if (playerScore > highScore) {
            PlayerPrefs.SetFloat("highscore" + PlayerPrefs.GetFloat("difficulty"), playerScore);
            highScore = playerScore;
        }


        string scoreMinutes = Mathf.Floor((playerScore % 3600) / 60).ToString("00");
        string scoreSeconds = (playerScore % 60).ToString("00");

        string highMinutes = Mathf.Floor((highScore % 3600) / 60).ToString("00");
        string highSeconds = (highScore % 60).ToString("00");

        scoreText.GetComponent<TextMeshProUGUI>().text = "Time: " + scoreMinutes + ":" + scoreSeconds;
        highscoreText.GetComponent<TextMeshProUGUI>().text = "Highscore: " + highMinutes + ":" + highSeconds;
    }

    void PressRestart() {
        SceneManager.LoadScene(1);
    }

    void PressMenu() {
        SceneManager.LoadScene(0);
    }

}
