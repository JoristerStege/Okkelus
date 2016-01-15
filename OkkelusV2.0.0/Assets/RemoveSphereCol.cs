using UnityEngine;
using System.Collections;

public class RemoveSphereCol : MonoBehaviour {
    [SerializeField]
    private Rigidbody player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        player.GetComponent<SphereCollider>().radius = 0.1f;
    }
}
