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
			if(instance == null)
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
	[SerializeField] private bool canTime = false;		// bool that determines wherther the timer can run or not
	[SerializeField] private Text timer;				// stores the UI element for the timer that will tick up
	[SerializeField] private float timePassed;			// how much time has passed
	[SerializeField] private float speed = 1.0f;		// speed multiplier for the timer, for testing purposes
	
	[Header("Health and End State")]
	[SerializeField] private int health = 3;			// how many lives the players has

	[SerializeField] private GameObject[] heartIcons;   //list of icons for hearts
	private int healthLost = 0;

	[SerializeField] private EnemyManager enemyManager;
    [SerializeField] private DamageFlash flash;

	private void Start()
	{
	    canTime = true;		// starts the timer
		for (int i = 0; i < heartIcons.Length; i++)
		{
			heartIcons[i].GetComponent<Animator>().enabled = false;
		}

        playerCamera = Camera.main.transform;
        startPosition = playerCamera.localPosition;
        initialDuration = duration;
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

        if (shouldShake) {
            if (duration > 0) {
                playerCamera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }

            else {
                shouldShake = false;
                duration = initialDuration;
                playerCamera.localPosition = startPosition;
            }
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
		heartIcons[healthLost].GetComponent<Animator>().enabled = true;
		healthLost++;

        //flash screen
        flash.StartDamageFlash();

		//kills all enemies
		enemyManager.DestroyAllEnemies();

        shouldShake = true;
	}

	public int GetHealth()
	{
		return health;
	}



    public float power = 10f;
    public float duration = .5f;
    public Transform playerCamera;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;


}
