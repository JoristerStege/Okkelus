using UnityEngine;
using System.Collections;

public class TriggerTiles : MonoBehaviour {

    public GameObject tiles;
    private GameObject[] tileArr;
    public float time;
    public float repeatRate;
    int index;
    int childNumber;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Test");
            index = 0;
            childNumber = tiles.transform.childCount;
            InvokeRepeating("ApplyGravity", time, repeatRate);
        }
    }

    void ApplyGravity()
    {
        if (index < childNumber)
        {
            tiles.transform.GetChild(index).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            tiles.transform.GetChild(index).gameObject.GetComponent<Rigidbody>().useGravity = true;
            
            //tile.GetComponent<Rigidbody>().useGravity = true;
            index++;
            return;
        }
        CancelInvoke("ApplyGravity");
        index = 0;
    }
}
