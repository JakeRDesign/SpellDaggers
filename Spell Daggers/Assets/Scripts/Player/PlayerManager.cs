using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[Tooltip("The player one character")]
	[SerializeField] private PlayerOne m_playerOne;
	[Tooltip("The player two character")]
	[SerializeField] private PlayerTwo m_playerTwo;

	[Tooltip("How fast the player'll rotate with one player moving in a direction")]
	[SerializeField] private float m_rotationSpeed;

	//how much rotation we need
	private float m_movement;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		m_movement = m_playerOne.GetMovement() + m_playerTwo.GetMovement();

		transform.Rotate(Vector3.forward, m_movement * m_rotationSpeed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//swap enemy1 and enemy2 with whatever the enemy tags end up being
		if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2")
		{
			Timer.Instance.TakeDamage();
			//TODO deleting all enemies on screen when hit
		}
	}
}
