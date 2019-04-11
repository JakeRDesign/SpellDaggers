using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsManager : MonoBehaviour {

    [HideInInspector] public float playerScore;
    [HideInInspector] public float highScore;

    private bool newHighscore;

    public Button menuButton;
    public Button restartButton;

    public GameObject scoreText;
    public GameObject highscoreText;

    public GameObject newHighscorePanel;
    private float highscoreAlpha;
    private bool increaseAlpha;

    
    void Start () {
        menuButton.GetComponent<Button>().onClick.AddListener(PressMenu);
        restartButton.GetComponent<Button>().onClick.AddListener(PressRestart);

        playerScore = PlayerPrefs.GetFloat("Score");
        highScore = PlayerPrefs.GetFloat("Highscore");

        if (playerScore > highScore) {
            PlayerPrefs.SetFloat("Highscore", highScore);
            newHighscore = true;
            highScore = playerScore;
        }

        scoreText.GetComponent<TextMeshProUGUI>().text = "Time: " + playerScore.ToString();
        highscoreText.GetComponent<TextMeshProUGUI>().text = "Highscore: " + highScore.ToString();
    }

    void Update() {
        if (newHighscore) {

            if (increaseAlpha) {
                highscoreAlpha += Time.deltaTime * 1f;
                if (highscoreAlpha > 1f) increaseAlpha = false;
            }
            else {
                highscoreAlpha -= Time.deltaTime * 1f;
                if (highscoreAlpha < .3f) increaseAlpha = true;
            }

            newHighscorePanel.GetComponent<CanvasGroup>().alpha = highscoreAlpha;
        } else {
            newHighscorePanel.GetComponent<CanvasGroup>().alpha = highscoreAlpha;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.SetFloat("Score", 0);
            PlayerPrefs.SetFloat("Highscore", 0);
        }
    }

    void PressRestart() {
        SceneManager.LoadScene(1);
    }

    void PressMenu() {
        SceneManager.LoadScene(0);
    }

}
