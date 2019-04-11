using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	#region Singleton management
	private static Timer instance = null;
	public static Timer Instance
	{
		get
		{
			//if timer doesn't already exist
			if(instance = null)
			{
				instance = FindObjectOfType<Timer>();
			}

			if(instance == null)
			{
				//create a gameobject for itself that can't be replaced
				GameObject go = new GameObject();
				go.name = "Timer";
				instance = go.AddComponent<Timer>();
			}
		return instance;
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			//set instance
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private Timer() { }
	#endregion

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
		if (canTime == true)
		{
			timePassed += Time.deltaTime * speed;
			//string hours = (timePassed % 3600).ToString("00");
			string minutes = Mathf.Floor((timePassed % 3600) / 60).ToString("00");
			string seconds = (timePassed % 60).ToString("00");
			timer.text = /*hours + ":" + */minutes + ":" + seconds;
		}
	}

	//ends the game
	void EndState()
	{
		canTime = false;
		PlayerPrefs.SetFloat("score", timePassed);
		SceneManager.LoadScene(2);
	}

	public void TakeDamage()
	{
		//reduce health
		health -= 1;

		//if health is low enough, trigger end state
		if (health <= 0)
		{
			EndState();
		}
	}
}
