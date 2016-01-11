using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {
    public float pickUpDist = 1f;
    private Transform carriedObject = null;
    private int pikcupLayer = 1 << LayerMask.NameToLayer("Pickup");

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
