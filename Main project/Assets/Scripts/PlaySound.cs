using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    AudioClip growl;
    AudioSource player;

	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        player.clip = growl;
        player.Play();
	}

    public void Play()
    {
        player.clip = growl;
        player.Play();
    }

    public void Stop()
    {
        player.Stop();
    }

}
