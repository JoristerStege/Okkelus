using UnityEngine;
using System.Collections;

public class PickupBooks : MonoBehaviour 
{
    private Camera cam;    
    private GameObject pickup;
    private Rigidbody rb;
    private bool gotObject, lmUp, rmUp;

    void Start()
    {
        gotObject = false;
        Cursor.visible = false;
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lmUp = true;
        }

        else if (Input.GetMouseButtonUp(1))
        {
            rmUp = true;
        }

        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }
    }

    void FixedUpdate()
    {
        if (lmUp)
        {
            if (!gotObject)
            {
                PickupObject();
            }
            lmUp = false;
        }

        if (rmUp)
        {
            if (gotObject)
            {
                DropObject();
            }
            rmUp = false;
        }

        if (gotObject)
        {
            DragObject();
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Book"))
            Physics.IgnoreCollision(this.GetComponent<Collider>(), col.collider); // Dion
        //Physics.IgnoreCollision((Collider)GetComponent(typeof(CapsuleCollider)), col.collider); // Jordi       
    }

    private void DropObject()
    {
        gotObject = false;
        pickup.transform.parent = null;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(cam.transform.forward * 1000f);
        rb = null;
        pickup = null;
    }

    private void DragObject()
    {
        pickup.transform.position = cam.transform.position + cam.transform.forward * 0.8f;
    }

    private void PickupObject()
    {
        RaycastHit hit;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward * 1.5f);

        if (Physics.Raycast(ray, out hit))
        {
            //Transform targetObject = hit.transform;
            if (hit.collider.attachedRigidbody == null) return;
            pickup = hit.collider.gameObject;

            if (hit.rigidbody.CompareTag("Book"))
            {
                if (Vector3.Distance(pickup.transform.position, cam.transform.position) < 2)
                {
                    //pickup.transform.parent = gameObject.transform;
                    pickup.transform.parent = gameObject.transform;
                    rb = pickup.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    //rb = pickup.GetComponent<Rigidbody>();
                    gotObject = true;
                }
                else
                {
                    pickup = null;
                }
            }
        }
    }
}
