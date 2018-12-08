using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {
    public Image fade;
    float time = 1.0f;
    float fades = 0.0f;
    float start = 0f;
    float end = 0f;
    bool fadeinout = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeIO()
    {
        while (!fadeinout)
        {
            Fadein();
        }
        while (fadeinout)
        {
            Fadeout();
        }
    }

    void Fadein()
    {
        Debug.Log("fadein");

        time += Time.deltaTime;
        if(fades >=0.6f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(255, 0, 0, fades);
            time = 0;
        }
        else if(fades <= 0.6f)
        {
            fadeinout = true;
        }
    } 

    void Fadeout()
    {
        Debug.Log("fadeout");

        time += Time.deltaTime;
        if (fades < 1.0f && time >= 0.1f)
        {
            fades += 0.1f;
            fade.color = new Color(255, 0, 0, fades);
            time = 0;
        }
        else if (fades >= 1.0f)
        {
            fadeinout = false;
        }
    }
}
