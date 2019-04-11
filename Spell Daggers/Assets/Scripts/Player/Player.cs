using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement of this player, 1 is clockwise, 0 is neutral, -1 is counter clockwise
	protected float m_movement;

	//internal timer for cooldown between shots
	protected float m_timer = 0.0f;

	[Tooltip("How long in seconds between shots")]
	[SerializeField] protected float m_shotCooldown;

	[Tooltip("Prefab for the bullet")]
	[SerializeField] protected GameObject m_bulletPrefab;

    [Tooltip("The empty GO where the bullet will be spawned from")]
    [SerializeField] protected Transform bulletSpawnPoint;                                             // Game Object that stores the empty spawn point

    //bool for checking if the fire button has been let up before shooting again
    protected bool m_fired;

	// Update is called once per frame
	protected void Update()
	{
		m_timer += Time.deltaTime;
	}

	public float GetMovement()
	{
		return m_movement;
	}

	protected void Fire()
	{
		GameObject shotBullet = Instantiate(m_bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		m_timer = 0.0f;
	}
}
