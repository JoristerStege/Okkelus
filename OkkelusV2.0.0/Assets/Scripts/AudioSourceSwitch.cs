using UnityEngine;using System.Collections;

public class AudioSourceSwitch : MonoBehaviour {

	// Use this for initialization
    private AudioSource playerAudio;
    private AudioClip[] audiolist;
    private int amountOfClips;

    void Start ()
    {
        playerAudio = GetComponent<AudioSource>();
        amountOfClips = 5;
        audiolist = new AudioClip[amountOfClips];
        LoadAudio();
        playerAudio.clip = audiolist[0];
        playerAudio.Play();
    }
	
	// Update is called once per frame
    void Update()
    {
    }

    void LoadAudio()
    {
        audiolist[0] = Resources.Load("Tutorial") as AudioClip;
        audiolist[1] = Resources.Load("Opbouwende Spanning") as AudioClip;
        audiolist[2] = Resources.Load("Tutorial") as AudioClip;
        audiolist[3] = Resources.Load("Tutorial") as AudioClip;
        audiolist[4] = Resources.Load("Tutorial") as AudioClip;
    }
    
    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.name)
        {
            case "audioTrigger" :// add the first trigger name here
                playerAudio.Stop();
                playerAudio.clip = audiolist[1];
                playerAudio.Play();
            break;

            case "DoorTop (8)" :
                playerAudio.Stop();
                playerAudio.clip = audiolist[2];
                playerAudio.Play();
            break;

            case "trigger" :
                playerAudio.Stop();
                playerAudio.clip = audiolist[3];
                playerAudio.Play();
            break;

            case "creditsTrigger" :
                playerAudio.Stop();
                playerAudio.clip = audiolist[1];
                playerAudio.Play();
            break;

            default:
            break;
        }
    }
}
