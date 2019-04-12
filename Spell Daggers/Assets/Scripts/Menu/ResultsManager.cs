﻿using System.Collections;
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

    void Start () {
        menuButton.GetComponent<Button>().onClick.AddListener(PressMenu);
        restartButton.GetComponent<Button>().onClick.AddListener(PressRestart);

        playerScore = PlayerPrefs.GetFloat("score");
        highScore = PlayerPrefs.GetFloat("highscore");

        if (playerScore > highScore) {
            PlayerPrefs.SetFloat("highscore", highScore);
            newHighscore = true;
            highScore = playerScore;
        }

        scoreText.GetComponent<TextMeshProUGUI>().text = "Time: " + playerScore.ToString();
        highscoreText.GetComponent<TextMeshProUGUI>().text = "Highscore: " + highScore.ToString();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.SetFloat("score", 0);
            PlayerPrefs.SetFloat("highscore", 0);
        }
    }

    void PressRestart() {
        SceneManager.LoadScene(1);
    }

    void PressMenu() {
        SceneManager.LoadScene(0);
    }

}
