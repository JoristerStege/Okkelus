using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

    void ApplyGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
    }
}
