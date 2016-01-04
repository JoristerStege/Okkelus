using UnityEngine;
using System.Collections;

public class CrouchScript : MonoBehaviour {
    public CapsuleCollider CapCollider;
    public Rigidbody RigidBody;
    public Camera Cam;
    
    private float height;
    private float crouchHight;
    private float camHeight;
    private float stndheight;
    private float width;
    // Use this for initialization
	void Start () {
        height = CapCollider.height;
        width = CapCollider.radius;
        crouchHight = 0.5f;
        stndheight = Cam.transform.position.y;
        camHeight = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        CapCollider.height = height / 2;

         CapCollider.height = height;
        // Cam.transform.position.Set(Cam.transform.position.x, stndheight, Cam.transform.position.z);
        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.LeftControl)) 
        {
            //if (height < 2)
            //{
                CapCollider.height = crouchHight;
            //   // Cam.transform.position.Set(Cam.transform.position.x, camHeight, Cam.transform.position.z);
            //}
            //else
            //{
                CapCollider.height = height / 2;
                width = width / 2;
                
               // Cam.transform.position.Set(Cam.transform.position.x, camHeight, Cam.transform.position.z);
               
            //}
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
