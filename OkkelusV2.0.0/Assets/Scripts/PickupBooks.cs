using UnityEngine;
using System.Collections;

public class PickupBooks : MonoBehaviour
{
    private Camera cam;
    private GameObject pickup;
    private Rigidbody rb;
    private bool gotObject, pickupBtnPressed;

    void Start()
    {
        gotObject = false;
        cam = GetComponentInChildren<Camera>();
        pickupBtnPressed = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            pickupBtnPressed = !pickupBtnPressed;
        }
    }

    void FixedUpdate()
    {
        if (gotObject)
        {
            if (pickupBtnPressed)
            {
                DropObject();
                pickupBtnPressed = false;
            }
            else DragObject();
        }
        else if (!gotObject && pickupBtnPressed)
        {
            PickupObject();
            pickupBtnPressed = false;
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
        rb.AddForce(cam.transform.forward * 500f);
        rb = null;
        pickup = null;
    }

    private void DragObject()
    {
        pickup.transform.position = cam.transform.position + cam.transform.forward * 1.2f;
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
                    pickup.transform.parent = gameObject.transform;
                    rb = pickup.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
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