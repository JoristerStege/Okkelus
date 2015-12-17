using UnityEngine;
using System.Collections;

public class MoveGhoul : MonoBehaviour {

    Animator anim;
    NavMeshAgent nav;
    Transform player;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
    }
}
