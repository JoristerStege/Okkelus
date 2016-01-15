using UnityEngine;
using System.Collections;

public class randomNumberPuzzle : MonoBehaviour {
    
    MeshRenderer renderer;
    public Material[] textures;
    int random;
    int i;
    
	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<MeshRenderer>();
        i = 0;
            }
	
	// Update is called once per frame
	void Update () {
        i++;
        if (i == 30)
        {
            SetTexture();
            i = 0;
        }
	}

    void SetTexture()
    {
        random = Random.Range(0, 9);
        renderer.material = textures[random];
    }
}
