using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player
{

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		m_movement = Input.GetAxisRaw("PlayerOneRotation");
	}
}
