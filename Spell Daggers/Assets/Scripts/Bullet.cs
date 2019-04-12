using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;

	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
	}

    public void BulletCollided()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("destroy", true);
        bulletSpeed = 0;
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
