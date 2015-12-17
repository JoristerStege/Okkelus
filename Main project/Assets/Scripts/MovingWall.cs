using UnityEngine;
using System.Collections;

public class MovingWall : MonoBehaviour 
{
    public GameObject wall;
    public GameObject player;
    private bool moveWall;
    public AudioClip ambientClip;
    public AudioClip jumpscareClip;
    private bool playOnce;
    AudioSource audio;

	// Use this for initialization
	void Start () 
    {
        moveWall = false;
        audio = GetComponent<AudioSource>();
        playOnce = false;
        wall.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        float distance = wall.transform.position.z - player.transform.position.z;
        if (distance < 1.8f)
        {
            moveWall = false;
        }
        if (Vector3.Distance(transform.position, wall.transform.position) < 5f)
        {
            if (!playOnce) { audio.PlayOneShot(jumpscareClip, 0.7f); playOnce = true; }
        }
        
        if (Input.GetKeyUp(KeyCode.Y))
        {
            //if (!playOnce) { audio.PlayOneShot(jumpscareClip, 0.7f); playOnce = true; }
        }
        //Debug.Log(Vector3.Distance(transform.position, wall.transform.position));
	}

    void FixedUpdate()
    {
        if (moveWall)
        {
            Vector3 viewPortPoint = Camera.main.WorldToViewportPoint(wall.transform.position);
            bool onScreen = viewPortPoint.z > 0 && viewPortPoint.x > -1 && viewPortPoint.x < 2 && viewPortPoint.y > -1 && viewPortPoint.y < 2;
            if (!onScreen)
            {
                wall.SetActive(true);
            }
            if (onScreen && wall.activeInHierarchy)
            {
                wall.transform.position = new Vector3(wall.gameObject.transform.position.x, wall.gameObject.transform.position.y, wall.gameObject.transform.position.z - 1.0f);
            }

            
        }
        /*
        if (moveWall)
        {
            wall.transform.position = new Vector3(wall.gameObject.transform.position.x, wall.gameObject.transform.position.y, wall.gameObject.transform.position.z - 0.2f);
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            

            Debug.Log("Wall trigger");
            moveWall = true;
            //AudioSource.PlayClipAtPoint(ambientClip, wall.transform.position);
        }
    }
}
