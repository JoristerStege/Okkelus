using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintPopUp : MonoBehaviour
{

    public Text hintText;
    public PickupClothes PClothes;
    private bool hasCollided;
    private int hintTime;

    void Start()
    {
        hintText.text = "";
        hintTime = 0;
        hasCollided = false;
        hintText.enabled = false;   
    }

    void Update()
    {
        if (hasCollided)
        {
            hintTime += 1;

            if (hintTime > 300)
            {
                hintText.enabled = false;
                hasCollided = false;
                hintTime = 0;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Trigger"))
        {
            hintText.text = col.gameObject.name.ToString();
            Destroy(col.gameObject);
            
            hasCollided = true;
            hintText.enabled = true;
            if (PClothes.gotClothes == true)
            {
                hintText.enabled = false;
            }
        }
    }
}
