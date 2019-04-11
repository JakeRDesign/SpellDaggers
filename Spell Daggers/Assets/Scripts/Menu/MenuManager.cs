using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Button playButton;
    public Button exitButton;

	void Start () {
        playButton.GetComponent<Button>().onClick.AddListener(PressPlay);
        exitButton.GetComponent<Button>().onClick.AddListener(PressExit);
    }

    void PressPlay() {
        SceneManager.LoadScene(1);
    }

    void PressExit() {
        Application.Quit();
    }
}
