using UnityEngine;
using System.Collections;

public class ActieTrigger : MonoBehaviour {

    public GameObject floor;
   
    public Material[] lavaArray;
   
    private bool isLava;
    private int index;
    private int lavaSpeed;

    MeshRenderer rend;

	// Use this for initialization
	void Start () {
        rend = floor.GetComponent<MeshRenderer>();
        isLava = false;
        index = 0;
        lavaSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLava && lavaSpeed == 5)
        {
            rend.material = lavaArray[index];
            lavaSpeed = 0;
            index++;
        }
        
        if (isLava)
        {
            lavaSpeed++;
        }
        if (index == 44)
        {
            index = 0;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isLava = true;
        }
    }

    public bool IsLava()
    {
        return isLava;
    }
}
