using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{

    // Use this for initialization
    public Camera cam;
    public string gameObjectTag = "Door";
    public float startAngleX;
    public float EndAngleX;
    public float rotateAmountX;

    public float startAngleY;
    public float EndAngleY;
    public float rotateAmountY;

    public float startAngleZ;
    public float EndAngleZ;
    public float rotateAmountZ;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == gameObjectTag)
            if (Input.GetKey(KeyCode.Joystick1Button2))
                OpenDoorNow(other);
    }
    void OpenDoorNow(Collider collider)
    {
        Vector3 direction = collider.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < cam.fieldOfView * 0.7f)
        {
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10))
            {
                Debug.DrawRay(transform.position, direction, Color.red, 20);
                if (hit.transform.tag == gameObjectTag)
                {
                    collider.transform.Rotate(
                    collider.transform.eulerAngles.x < EndAngleX ? rotateAmountX : 0,
                    collider.transform.eulerAngles.y < EndAngleY ? rotateAmountY : 0,
                    collider.transform.eulerAngles.z < EndAngleZ ? rotateAmountZ : 0);
                }
            }

        }

    }
}
