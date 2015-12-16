using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyMoving;
    public GameObject enemyStatic;

    public AudioSource sound1;
    public AudioClip test;

    private bool moveEnemy;
    private bool playOnce;
    private bool enemySpawned;
    private bool startMoving;

    // Use this for initialization
    void Start()
    {
        moveEnemy = false;
        playOnce = false;
        enemyMoving.SetActive(false);
        enemySpawned = false;
        startMoving = false;
        enemyStatic.SetActive(false);
        sound1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        EndPointEnemy();
        PlayScareAudio();
    }


    void FixedUpdate()
    {
        if (moveEnemy)
        {
            if (!OnScreen(enemyMoving.transform.position))
            {
                if (!enemyMoving.activeInHierarchy)
                {
                    enemyMoving.SetActive(true);
                }
            }

            if (OnScreen(enemyMoving.transform.position) && enemySpawned == false && enemyMoving.activeInHierarchy == true)
            {
                startMoving = true;
                enemySpawned = true;

            }

            if (startMoving)
            {
                float distance = enemyMoving.transform.position.z - player.transform.position.z;
                if (distance < 11)
                {
                    enemyMoving.transform.position = new Vector3(player.transform.position.x, enemyMoving.transform.position.y, enemyMoving.transform.position.z - 1.0f);
                }
                else
                {
                    enemyMoving.transform.position = new Vector3(player.transform.position.x, enemyMoving.transform.position.y, enemyMoving.transform.position.z - 0.8f);
                }
            }

            if (enemySpawned)
            {
                enemyStatic.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyStatic.SetActive(true);    
            Debug.Log("Wall trigger");
            moveEnemy = true;
            StartCoroutine(DisableEnemy(5, enemyStatic));
            sound1.clip = test;
            sound1.Play();
        }
    }

    IEnumerator DisableEnemy(int seconds, GameObject enemy)
    {
        yield return new WaitForSeconds(seconds);
        enemy.SetActive(false);

    }

    private bool OnScreen(Vector3 pos)
    {
        Vector3 viewPortPoint = Camera.main.WorldToViewportPoint(pos);
        bool onScreen = viewPortPoint.z > 0 && viewPortPoint.x > -1 && viewPortPoint.x < 2 && viewPortPoint.y > -1 && viewPortPoint.y < 2;
        return onScreen;
    }

    private void EndPointEnemy()
    {
        float distance = enemyMoving.transform.position.z - player.transform.position.z;
        if (distance < 1.5f)
        {
            moveEnemy = false;
        }
    }

    private void PlayScareAudio()
    {
        if (Vector3.Distance(player.transform.position, enemyMoving.transform.position) < 5f)
        {
            
        }
    }
}