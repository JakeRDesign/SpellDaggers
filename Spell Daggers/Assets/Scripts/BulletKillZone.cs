using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillZone : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Red" || other.gameObject.tag == "Blue")
        {
            Destroy(other.gameObject);
            Debug.Log("bullet destroyed");
        }
    }
}
