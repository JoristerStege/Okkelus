using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PickupClothes : MonoBehaviour
{
    public Camera cam;
    public GameObject clothes;
    public Image panel;
    private Color fadeColor;

    public bool gotClothes;

    public float distance;

    enum FadeState
    {
        FadeIn,
        FadeOut,
        Stop
    }

    FadeState fadeState;

    // Use this for initialization
    void Start()
    {
        gotClothes = false;
        fadeColor = Vector4.zero;
        fadeState = FadeState.Stop;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button2) && !gotClothes)
        {
            PickupObject();
        }

        FadeScreen();
    }

    private void PickupObject()
    {
        if (Vector3.Distance(cam.transform.position, clothes.transform.position) <= distance)
        {
            fadeState = FadeState.FadeOut;
            gotClothes = true;
        }
    }

    private void FadeScreen()
    {
        switch (fadeState)
        {
            case FadeState.FadeOut:
                if (panel.color.a >= 1) { fadeState = FadeState.FadeIn; Destroy(clothes); return; };
                fadeColor.a += 0.01f;
                panel.color = fadeColor;
                break;
            case FadeState.FadeIn:
                if (panel.color.a <= 0) { fadeState = FadeState.Stop; return; }
                fadeColor.a -= 0.01f;
                panel.color = fadeColor;
                break;
            case FadeState.Stop:
                break;
            default:
                break;
        }
    }

    public bool GotClothes()
    {
        return gotClothes;
    }
}