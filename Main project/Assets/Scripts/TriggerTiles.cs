using UnityEngine;
using System.Collections;

public class TriggerTiles : MonoBehaviour
{
    public GameObject tiles;
    private GameObject[] tileArr;
    public GameObject Collider;
    public float time;
    public float repeatRate;
    int index;
    int childNumber;
    bool EnteredTrigger = false;

    void Update()
    {
        if (EnteredTrigger)
        {
            index = 0;
            childNumber = tiles.transform.childCount;
            InvokeRepeating("ApplyGravity", time, repeatRate);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnteredTrigger = true;
            Collider.SetActive(false);
        }
    }

    void ApplyGravity()
    {
        if (index < childNumber)
        {
            tiles.transform.GetChild(index).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            tiles.transform.GetChild(index).gameObject.GetComponent<Rigidbody>().useGravity = true;

            //tile.GetComponent<Rigidbody>().useGravity = true;
            index++;
            return;
        }
        CancelInvoke("ApplyGravity");
        index = 0;
    }
}