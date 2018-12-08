using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour {

    private static Image myImage;

    private float animTime = 0.5f; //Fade 애니메이션 재생 시간

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;

    private bool isplay = false;

    void Update()
    {

    }

    public static void setImage(int data)
    {
        //Debug.Log(data);
        myImage = GameObject.Find("Image").GetComponent<Image>();
        var imgcolor = myImage.color;
        imgcolor.a = 1f;
        myImage.color = imgcolor;
        switch (data)
        {
            case 1:
                myImage.sprite = Resources.Load<Sprite>("Image/bad");
                break;
        }
        imgcolor = myImage.color;
        imgcolor.a = 0f;
        myImage.color = imgcolor;
    }

    IEnumerator PlayFadeIn()
    {
        isplay = true;
        Color color = myImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while(color.a < 0.5f)
        {
            time += Time.deltaTime / animTime;
            color.a = Mathf.Lerp(start, end, time);
            myImage.color = color;
            yield return null;
        }
        isplay = false;
    }
}
