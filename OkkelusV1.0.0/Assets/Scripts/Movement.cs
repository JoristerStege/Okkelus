using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private bool playerInRange;
    private float timer;
    private float timeBetweenAttacks;

    Animator anim;
    NavMeshAgent nav;
    Transform player;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        nav.SetDestination(player.position);
        if (playerInRange)
        {

            Debug.Log("Test");
            anim.SetTrigger("Attack");
            Attack();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Test");
            //playerInRange = true;
            anim.SetTrigger("Attack");
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }


    void Attack()
    {
        timer = 0f;
        Debug.Log("Test");
        anim.SetBool("IsAttacking", true);
    }
}
