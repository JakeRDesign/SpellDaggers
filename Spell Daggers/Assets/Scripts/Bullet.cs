using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;

	// Update is called once per frame
	void Update ()
    {
        transform.position += -transform.right * bulletSpeed * Time.deltaTime;
	}
}
