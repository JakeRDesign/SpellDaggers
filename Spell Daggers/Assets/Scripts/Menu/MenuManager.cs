using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    // Main Buttons
    public Button playButton;
    public Button creditsButton;
    public Button exitButton;

    // UI Panels
    public GameObject menuPanel;
    public GameObject difficultyPanel;
    public GameObject creditsPanel;

    // Back Buttons
    public Button backButton;
    public Button creditsBackButton;

    // Difficulty Buttons
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    // View State
    CurrentView currentView;
    public enum CurrentView {

        MenuView,
        DifficultyView,
        CreditsView,

    }

    void Start () {

        // Assign buttons to methods
        playButton.GetComponent<Button>().onClick.AddListener(PressPlay);
        creditsButton.GetComponent<Button>().onClick.AddListener(PressCredits);
        exitButton.GetComponent<Button>().onClick.AddListener(PressExit);

        easyButton.GetComponent<Button>().onClick.AddListener(PressEasy);
        mediumButton.GetComponent<Button>().onClick.AddListener(PressMedium);
        hardButton.GetComponent<Button>().onClick.AddListener(PressHard);

        backButton.GetComponent<Button>().onClick.AddListener(PressBack);
        creditsBackButton.GetComponent<Button>().onClick.AddListener(PressBack);

        // Set the view to the main menu
        currentView = CurrentView.MenuView;
    }

    void Update() {

        // Show and hide panels depending on view
        switch (currentView) {
            case CurrentView.MenuView:
                menuPanel.SetActive(true);
                difficultyPanel.SetActive(false);
                creditsPanel.SetActive(false);
                break;

            case CurrentView.DifficultyView:
                menuPanel.SetActive(false);
                difficultyPanel.SetActive(true);
                creditsPanel.SetActive(false);
                break;

            case CurrentView.CreditsView:
                menuPanel.SetActive(false);
                difficultyPanel.SetActive(false);
                creditsPanel.SetActive(true);
                break;

            default:
                menuPanel.SetActive(true);
                difficultyPanel.SetActive(false);
                creditsPanel.SetActive(false);
                break;
        }

    }

    void PressPlay() {
        currentView = CurrentView.DifficultyView;
    }

    void PressCredits() {
        currentView = CurrentView.CreditsView;
    }

    void PressExit() {
        Application.Quit();
    }

    void PressEasy() {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("difficulty", 1);
    }

    void PressMedium() {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("difficulty", 2);
    }

    void PressHard() {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("difficulty", 3);
    }

    void PressBack() {
        currentView = CurrentView.MenuView;
    }
}
