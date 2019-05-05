using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour {

    public static ShowImage Instance;

    private Image myImage;
    private Sprite sprite;
    private float start = 1f;
    private IEnumerator coroutine;

    private bool isplay = false;

    void Awake()
    {
        Instance = this;
    }

    public void setImage(int data)
    {
        start = 1f;
        myImage = GameObject.Find("Image").GetComponent<Image>();
        //Debug.Log(data);
        var imgcolor = myImage.color;
        imgcolor.a = 1f;
        myImage.color = imgcolor;
        switch (data)
        {
            case 1:
                sprite = Resources.Load<Sprite>("Image/bad");
                break;
            case 2:
                sprite = Resources.Load<Sprite>("Image/good");
                break;
        }
        myImage.sprite = sprite;
        if(coroutine == null)
        {
            coroutine = PlayFadeIn();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator PlayFadeIn()
    {
        Color color = myImage.color;
        while (start != 0f)
        {
            start -= 0.1f;
            color.a = start;
            myImage.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
