using UnityEngine;
using System.Collections;

public class Picture_Rotation : MonoBehaviour {

    MeshRenderer rnd;
    public Material[] pictures;
    int index;
    float pictureSpeed;
	// Use this for initialization
	void Start () {
        rnd = this.GetComponent<MeshRenderer>();
        index = 0;
        pictureSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {

        pictureSpeed += Time.deltaTime;
        if (pictureSpeed >= 1)
        {
            rnd.material = pictures[index];
            pictureSpeed = 0;
            index++;
        }
        if (index == 3)
        {
            index = 0;
        }
	}
}
