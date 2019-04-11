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
	private new void Update()
	{
		base.Update();
		m_movement = Input.GetAxisRaw("PlayerOneRotation");
		if(Input.GetButtonDown("PlayerOneFire"))
		{
			if(m_timer >= m_shotCooldown && !m_fired)
			{
				Fire();
			}
			m_fired = true;
		}
		if(Input.GetButtonUp("PlayerOneFire"))
		{
			m_fired = false;
		}
	}
}
