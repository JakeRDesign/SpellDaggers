using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Button playButton;
    public Button exitButton;

    public GameObject menuPanel;
    public GameObject difficultyPanel;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public Button backButton;
    bool isShowingDifficulty;

    void Start () {
        playButton.GetComponent<Button>().onClick.AddListener(PressPlay);
        exitButton.GetComponent<Button>().onClick.AddListener(PressExit);

        easyButton.GetComponent<Button>().onClick.AddListener(PressEasy);
        mediumButton.GetComponent<Button>().onClick.AddListener(PressMedium);
        hardButton.GetComponent<Button>().onClick.AddListener(PressHard);

        backButton.GetComponent<Button>().onClick.AddListener(PressBack);

        difficultyPanel.SetActive(false);
    }

    void Update() {
        if (isShowingDifficulty) {
            menuPanel.SetActive(false);
            difficultyPanel.SetActive(true);
        } else {
            menuPanel.SetActive(true);
            difficultyPanel.SetActive(false);
        }
    }

    void PressPlay() {
        isShowingDifficulty = true;
    }

    void PressExit() {
        Application.Quit();
    }

    void PressEasy() {
        SceneManager.LoadScene(1);
    }

    void PressMedium() {
        SceneManager.LoadScene(1);
    }

    void PressHard() {
        SceneManager.LoadScene(1);
    }

    void PressBack() {
        isShowingDifficulty = false;
    }
}
