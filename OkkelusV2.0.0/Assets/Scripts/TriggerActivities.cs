using UnityEngine;
using System.Collections;

public class TriggerActivities : MonoBehaviour
{
    private Animator anim;

    public GameObject ghoul;
    public GameObject player;
    public GameObject ghoulStatic;
    public GameObject invisibleWall;
    public GameObject Floor;

    private AudioSource audio;
    private AudioSource growl;

    public AudioClip ambientClip;
    public AudioClip jumpscareClip;

    private BoxCollider col;

    private bool moveGhoul;
    private bool playOnce;
    private bool enemySpawned;
    private bool ghoulEnabled;
    private bool sawGhoul;
    public float timeLeft;

    // Use this for initialization
    void Start()
    {
        moveGhoul = false;
        audio = GetComponent<AudioSource>();
        playOnce = false;
        ghoul.SetActive(false);
        enemySpawned = false;
        ghoulEnabled = false;
        anim = ghoul.GetComponent<Animator>();
        ghoulStatic.SetActive(false);
        invisibleWall.SetActive(false);
        col = GetComponent<BoxCollider>();
        timeLeft = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        if (moveGhoul)
        {
            if (!OnScreen(ghoul.transform.position))
            {
                if (!ghoul.activeInHierarchy)
                {
                    ghoul.SetActive(true);
                }
            }

            if (OnScreen(ghoul.transform.position) && ghoulEnabled == false && ghoul.activeInHierarchy == true)
            {
                if (growl)
                {
                    growl.Stop();
                }

                ghoulEnabled = true;
            }

            if (ghoulEnabled)
            {
                ghoulStatic.SetActive(false);
                ghoul.transform.position = new Vector3(player.transform.position.x + 1.3f, ghoul.transform.position.y, player.transform.position.z);
                anim.SetTrigger("Attack");
                moveGhoul = false;
                PlayScareAudio();
            }
            if (ghoulEnabled && OnScreen(ghoul.transform.position))
            {
                PlayScareAudio();
            }
        }
        else if (ghoulEnabled)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
            if (timeLeft < 0)
            {
                DestroyImmediate(Floor);
                Debug.Log(ghoulEnabled);
                Debug.Log(Floor);
                ghoulEnabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Wall3.SetActive(false);
            Debug.Log("Wall trigger");
            moveGhoul = true;
            ghoulStatic.SetActive(true);
            float audioPosZ = player.transform.position.z;
            growl = PlayClipAtPoint(ambientClip, new Vector3(ghoulStatic.transform.position.x, ghoulStatic.transform.position.y, audioPosZ - 1.0f));
            StartCoroutine(DisableEnemy(5, ghoulStatic));
            invisibleWall.SetActive(true);
            col.isTrigger = false;
            col.transform.position = new Vector3(12, 12, 12);
            invisibleWall.GetComponent<Collider>().isTrigger = false;
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

    private void PlayScareAudio()
    {
        if (Vector3.Distance(player.transform.position, ghoul.transform.position) < 5f)
        {
            if (!playOnce) { audio.PlayOneShot(jumpscareClip, 0.7f); playOnce = true; }
        }
    }

    AudioSource PlayClipAtPoint(AudioClip clip, Vector3 pos)
    {
        GameObject gameObj = new GameObject("TempAudio");

        gameObj.transform.position = pos;

        AudioSource aSource = gameObj.AddComponent<AudioSource>();

        aSource.clip = clip;

        aSource.Play();

        Destroy(gameObj, clip.length);
        return aSource;

    }
}
