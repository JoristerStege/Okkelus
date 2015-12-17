using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{

    // Use this for initialization
    public float startAngleX;
    public float EndAngleX;
    public float rotateAmountX;

    public float startAngleY;
    public float EndAngleY;
    public float rotateAmountY;

    public float startAngleZ;
    public float EndAngleZ;
    public float rotateAmountZ;
	private bool useDoor;

    void DoorOpen()
    {
        useDoor = true;
    }
	void FixedUpdate()
	{
		transform.Rotate(
            transform.eulerAngles.x < EndAngleX ? rotateAmountX : 0,
            transform.eulerAngles.y < EndAngleY ? rotateAmountY : 0,
            transform.eulerAngles.z < EndAngleZ ? rotateAmountZ : 0);
	}
}