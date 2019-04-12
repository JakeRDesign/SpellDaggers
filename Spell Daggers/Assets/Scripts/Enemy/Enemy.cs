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
    public GameObject deathSprite = null;

    private float speed = 0;
    private Rigidbody2D rb = null;
    private EnemyManager manager = null;

	// Use this for initialization
	public void InitiateEnemy(EnemyManager em)
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        manager = em;
	}

    public void UpdateEnemy(Transform targetLocation)
    {
        Vector2 target = new Vector2(targetLocation.position.x, targetLocation.position.y);
        Vector2 newVelocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * speed * PlayerPrefs.GetFloat("difficulty");

        rb.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet b = collision.GetComponent<Bullet>();
        if (b != null)
            b.BulletCollided();
        else if (collision.tag == "Player")
        {
            Timer.Instance.TakeDamage();
        }


        if (isRed && collision.gameObject.tag == "Red" || !isRed && collision.gameObject.tag == "Blue")
            manager.DestroyEnemy(this);
    }

    private void OnDestroy()
    {
        if (deathSprite != null)
        {
            GameObject go = Instantiate(deathSprite, transform.position, Quaternion.identity);
            Destroy(go, go.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
