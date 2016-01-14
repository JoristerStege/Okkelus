using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    public Material lava;
    public ActieTrigger trigger;
    private bool isLava;

	// Use this for initialization
	void Start () {
        isLava = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (trigger.IsLava())
        {
            this.isLava = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.GetComponent<MeshRenderer>().material.ToString());

        if (this.isLava)
        {
            Debug.Log("Swagyolo430Blaze");
        }
    }
}
