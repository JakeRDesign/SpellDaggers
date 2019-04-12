using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillZone : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Red" || other.tag == "Blue")
        {
            Destroy(other);
        }
    }
}
