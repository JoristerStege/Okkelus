using UnityEngine;
using System.Collections;

public class Picture_Rotation : MonoBehaviour {

    MeshRenderer rnd;
    public Material[] pictures;
    int index;
    int pictureSpeed;
	// Use this for initialization
	void Start () {
        rnd = this.GetComponent<MeshRenderer>();
        index = 0;
        pictureSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        pictureSpeed++;
        if (pictureSpeed == 60)
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
