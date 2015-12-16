using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class inventoryUtility : MonoBehaviour {

	// Use this for initialization
    public Canvas canvas;
    [SerializeField]
    private LayerMask m_ItemLayer;
    [SerializeField]
    private float colliderRadius;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private string Tag = "Item";
    private GameObject[] items;
    private GameObject[] borders;
    private GameObject[] invLine;
    private int selectedItem;
    private bool triggerPres;
	void Start () {
        
        selectedItem = 0;
        items = new GameObject[5];
        borders = new GameObject[5];
        invLine = new GameObject[2];
        int tempItem = 0;
        int tempBorder = 0;
        int tempLine = 0;
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (canvas.transform.GetChild(i).gameObject.tag == "Item")
            {
                items[tempItem] = canvas.transform.GetChild(i).gameObject;
                items[tempItem++].SetActive(false);
            }
            else if (canvas.transform.GetChild(i).gameObject.tag == "Border")
            {
                borders[tempBorder] = canvas.transform.GetChild(i).gameObject;
                borders[tempBorder++].SetActive(false);
            }
            else
            {
                invLine[tempLine] = canvas.transform.GetChild(i).gameObject;
                invLine[tempLine++].SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton6))
            canvas.enabled = !canvas.enabled;
        if (Input.GetKeyUp(KeyCode.Tab))
            for (int i = 0; i < items.Length; i++)
            {
                borders[selectedItem++].SetActive(false);
                if (selectedItem > borders.Length - 1)
                    selectedItem = 0;
                borders[selectedItem].SetActive(items[selectedItem].activeSelf);
                if (items[selectedItem].activeSelf)
                    break;
            }
        if (Input.GetKeyUp(KeyCode.Z))
            for (int i = 0; i < items.Length; i++)
            {
                borders[selectedItem--].SetActive(false);
                if (selectedItem < 0)
                    selectedItem = items.Length - 1;
                borders[selectedItem].SetActive(items[selectedItem].activeSelf);
                if (items[selectedItem].activeSelf)
                    break;
            }
        if (Input.GetAxis("Inventory") != 0 && !triggerPres)
        {
            triggerPres = true;
            for (int i = 0; i < items.Length; i++)
            {
                borders[selectedItem].SetActive(false);
                if (Input.GetAxis("Inventory") < 0)
                {
                    selectedItem++;
                }
                if (Input.GetAxis("Inventory") > 0)
                {
                    selectedItem--;
                }
                if (selectedItem < 0)
                    selectedItem = items.Length - 1;
                if (selectedItem > items.Length - 1)
                    selectedItem = 0;
                borders[selectedItem].SetActive(items[selectedItem].activeSelf);
                if (items[selectedItem].activeSelf)
                    break;
            }
        }
        if (Input.GetAxis("Inventory") == 0 && triggerPres)
            triggerPres = false;

        if (Input.GetKeyUp(KeyCode.E))
        {
            Collider[] item = Physics.OverlapSphere(transform.position, colliderRadius, m_ItemLayer);
            for (int i = 0; i < item.Length; i++)
            {
                Vector3 direction = item[i].transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle < camera.fieldOfView * 0.7f)
                {
                    Ray ray = new Ray(transform.position, direction);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, direction.magnitude + 10))
                        if (hit.transform.CompareTag(Tag))
                        {
                            invLine[0].SetActive(true);
                            invLine[1].SetActive(true);
                            for (int j = 0; j < items.Length; j++)
                                if (items[j].name == hit.transform.name)
                                    items[j].SetActive(true);
                            Destroy(hit.transform.gameObject);
                        }
                }
            }
        }
	}
}
