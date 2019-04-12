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

        if (shouldShake) {
            if (duration > 0) {
                playerCamera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }

            else {
                shouldShake = false;
                duration = initialDuration;
                playerCamera.localPosition = startPosition;
            }
        }
    }

    public void BulletCollided()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("destroy", true);
        bulletSpeed = 0;
        shouldShake = true;
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }


    public float power = 1f;
    public float duration = .5f;
    public Transform playerCamera;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

    private void Start() {
        playerCamera = Camera.main.transform;
        startPosition = playerCamera.localPosition;
        initialDuration = duration;


    }

}
