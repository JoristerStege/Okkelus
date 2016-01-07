using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {

    float flickerSpeed;
    float time;

    public Light light;

	void Start () 
    {
        flickerSpeed = 2f;
        time = 0f;
        light.intensity = 0f;
	}
	
	void Update ()
    {
        time += Time.deltaTime;

        if ((int)time % flickerSpeed == 0)
        {
            light.intensity = 8f;
            flickerSpeed = Random.Range(1, 4);
        }
        else
        {
            light.intensity = 0f;
        }
	}
}
