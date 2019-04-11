using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [Header("Timer")]
    public bool canTime = false;                        // bool that determines wherther the timer can run or not
    public Text timer;                                  // stores the UI element for the timer that will tick up
    public float timePassed;                            // how much time has passed
    public float speed;                                 // speed multiplier for the timer, for testing purposes

    [Header("Health and End State")]
    public int health = 3;                              // how many lives the players have

    private void Start()
    {
        canTime = true;                                 // starts the timer
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        EndState();
    }

    // if you can time, update the timer
    void CountTime()
    {
        if (canTime == true)
        {
            timePassed += Time.deltaTime * speed;
            //string hours = (timePassed % 3600).ToString("00");
            string minutes = Mathf.Floor((timePassed % 3600) / 60).ToString("00");
            string seconds = (timePassed % 60).ToString("00");
            timer.text = /*hours + ":" + */minutes + ":" + seconds;
        }
    }

    void EndState()
    {
        if (health <= 0)
        {
            canTime = false;
            PlayerPrefs.SetFloat("score", timePassed);
        }
    }
}
