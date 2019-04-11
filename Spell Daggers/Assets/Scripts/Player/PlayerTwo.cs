using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : Player
{

    // stores the sound file played when a bullet is fired
    public AudioSource bulletFired;

    // Use this for initialization
    void Start()
	{
        bulletFired = this.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	private new void Update()
	{
		base.Update();
		m_movement = Input.GetAxisRaw("PlayerTwoRotation");
		if (Input.GetButtonDown("PlayerTwoFire"))
		{
			if (m_timer >= m_shotCooldown && !m_fired)
			{
				Fire();
                bulletFired.Play();
            }
			m_fired = true;
		}
		if (Input.GetButtonUp("PlayerTwoFire"))
		{
			m_fired = false;
		}
	}
}
