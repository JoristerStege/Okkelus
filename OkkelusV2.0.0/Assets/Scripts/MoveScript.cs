using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
    public GameObject ab;
    private Vector3 ofset;


    // Use this for initialization
    void Start () {
        ofset = ab.transform.position - transform.position;

    }

    // Update is called once per frame
    void Update () {
        ab.transform.position = transform.position + ofset;
    }
}
