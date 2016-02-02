using UnityEngine;
using System.Collections;

public class PlayerOpenDoor : MonoBehaviour
{
    // Use this for initialization
    public Camera cam;
    public string gameObjectTag = "Door";

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == gameObjectTag)
            if (Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.E))
                OpenDoorNow(other);
    }
    void OpenDoorNow(Collider collider)
    {
        Debug.Log(Vector3.Distance(transform.position, collider.transform.position));
        if (Vector3.Distance(transform.position, collider.transform.position) <= 4)
        {
            collider.BroadcastMessage("DoorOpen");
        }
        //Vector3 direction = collider.transform.position - transform.position;
        //float angle = Vector3.Angle(direction, transform.forward);
        //if (angle < cam.fieldOfView * 0.7f)
        //{
        //    Ray ray = new Ray(transform.position, direction);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 10))
        //        if (hit.transform.tag == gameObjectTag)
        //            hit.transform.BroadcastMessage("DoorOpen");
        //}
    }
}