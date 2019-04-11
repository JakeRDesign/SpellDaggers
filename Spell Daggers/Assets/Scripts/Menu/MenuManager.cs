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
        Debug.Log("Play");
        isShowingDifficulty = true;
    }

    void PressExit() {
        Debug.Log("1");
        Application.Quit();
    }

    void PressEasy() {
        Debug.Log("2");
        SceneManager.LoadScene(1);
    }

    void PressMedium() {
        Debug.Log("3");
        SceneManager.LoadScene(1);
    }

    void PressHard() {
        Debug.Log("4");
        SceneManager.LoadScene(1);
    }

    void PressBack() {
        Debug.Log("5");
        isShowingDifficulty = false;
    }
}
