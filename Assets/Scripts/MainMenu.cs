using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public Button Sound_Off_On;
    public RawImage OffImg, OnImg;
    public Text Tap_To_Start;
    Color a, b;

    // Update is called once per frame
    void Start()
    {
        OffImg = Sound_Off_On.transform.Find("ImageUI_Off").GetComponent<RawImage>();
        OnImg = Sound_Off_On.transform.Find("ImageUI_On").GetComponent<RawImage>();
        OffImg.enabled = false;
        Color a = b =  Tap_To_Start.color;
        a.a = 0;
    }
    bool gameStarted = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            gameObject.SetActive(false);
        }

        if (gameStarted == false)
        {
            float t = Mathf.PingPong(Time.time * 2, 1.0f);
            Tap_To_Start.color = Color.Lerp(a, b, t);
        }
    }

    public void ChangeTextureOnClick()
    {
        if (OffImg.enabled && !OnImg.enabled)
        {
            OffImg.enabled = false;
            OnImg.enabled = true;
        }

        else if (OnImg.enabled && !OffImg.enabled)
        {
            OnImg.enabled = false;
            OffImg.enabled = true;
        }
    }
}
