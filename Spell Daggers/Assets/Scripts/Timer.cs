using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public bool canTime = false;                        // bool that determines wherther the timer can run or not
    public Text timer;                                  // stores the UI element for the timer that will tick up
    public float timePassed;                            // how much time has passed
    public float speed;                                 // speed multiplier for the timer, for testing purposes

    private void Start()
    {
        canTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canTime == true)
        {
            timePassed += Time.deltaTime* speed;
            //string hours = (timePassed % 3600).ToString("00");
            string minutes = Mathf.Floor((timePassed % 3600)/60).ToString("00");
            string seconds = (timePassed % 60).ToString("00");
            timer.text = /*hours + ":" + */minutes + ":" + seconds;
        }
    }
}
