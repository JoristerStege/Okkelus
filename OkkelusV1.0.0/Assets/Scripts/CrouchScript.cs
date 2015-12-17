using UnityEngine;
using System.Collections;

public class CrouchScript : MonoBehaviour {
    public CapsuleCollider CapCollider;
    public Rigidbody RigidBody;
    
    private float height;
    private float crouchHight;
	// Use this for initialization
	void Start () {
        height = CapCollider.height;
        crouchHight = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        CapCollider.height = height;
        if (Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.LeftControl)) 
        {
            if (height < 2)
            {
                CapCollider.height = crouchHight;
            }
            else
            {
                CapCollider.height = height / 2;
            }
            //Vector3 scale = CapCollider.GetComponent(collider).transform.localScale;
            // scale.y *= 0.5f;
        }
        else
        {
            CapCollider.height = height;
            //CapCollider.collider.transform.localScale = scale;
        }
    }
}
