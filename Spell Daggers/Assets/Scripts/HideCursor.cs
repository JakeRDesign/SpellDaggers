using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour {

    public Canvas pause;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        if (pause.enabled == false)
        {
            Cursor.visible = false;
        }
	}
}