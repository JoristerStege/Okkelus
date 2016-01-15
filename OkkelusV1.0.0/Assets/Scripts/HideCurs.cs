using UnityEngine;
using System.Collections;

public class HideCurs : MonoBehaviour {
    bool x;
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if (!x)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKey(KeyCode.F3))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            x = !x;
        }
	}
}
