using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Tooltip("Whether or not this player is player one")]
	[SerializeField] private bool m_playerOne;

	//whether this player is pressing respective movement keys
	private bool m_movingRight = false;
	private bool m_movingLeft = false;

	//internal timer for cooldown between shots
	private float m_timer = 0.0f;

	[Tooltip("How long in seconds between shots")]
	[SerializeField] private float m_shotCooldown;

	//bool for checking if the fire button has been let up before shooting again
	private bool m_fired;
	
	// Update is called once per frame
	void Update ()
	{
		m_timer += Time.deltaTime;
	}
}
