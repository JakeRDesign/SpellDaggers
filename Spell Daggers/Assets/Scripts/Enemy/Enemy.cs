using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public bool isRed = true;

    private float speed = 0;
    private Rigidbody2D rb = null;
    private EnemyManager manager = null;

	// Use this for initialization
	public void InitiateEnemy(EnemyManager em)
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        manager = em;

        float randSpawnCoord = Random.Range(0.0f, 1.0f);
        Vector2 spawnPoint = new Vector2(randSpawnCoord, randSpawnCoord);

        switch(Random.Range(0, 4))
        {
            case 0: { spawnPoint.y = 1.1f;     break; }
            case 1: { spawnPoint.x = 1.1f;     break; }
            case 2: { spawnPoint.y = -0.1f;    break; }
            case 3: { spawnPoint.x = -0.1f;    break; }
            default: { Debug.Assert(false, "SpawnPoint randomiser switch statement fell to default"); break; }
        }

        Vector3 newPosition = Camera.main.ViewportToWorldPoint(spawnPoint);
        newPosition.z = 0;

        transform.position = newPosition;
	}

    public void UpdateEnemy(Transform targetLocation)
    {
        Vector2 target = new Vector2(targetLocation.position.x, targetLocation.position.y);
        Vector2 newVelocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * speed;

        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRed && collision.gameObject.tag == "Red" || !isRed && collision.gameObject.tag == "Blue")
            manager.DestroyEnemy(this);
    }
}
