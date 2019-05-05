using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrokenCubeMovement : MonoBehaviour {

    public static int LRUD;
    public static bool isOver = false;
    private float speed = 1f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        BrokencubeTranslate(LRUD);
        if (transform.position.y < 0)
            Destroy(this.gameObject);
	}


    private void BrokencubeTranslate(int LRUD)
    {
        if (transform.name.Contains("CubeU"))
        {
            switch (transform.name)
            {
                case "CubeUL":
                    //transform.rotation = Quaternion.AngleAxis(-30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * speed, ForceMode.Impulse);
                    break;
                case "CubeUR":
                    //transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * speed, ForceMode.Impulse);
                    break;
            }
            //transform.Translate(new Vector3(0, speed * Time.deltaTime, -0.4f))
        }
        else if (transform.name.Contains("CubeD"))
        {
            switch (transform.name)
            {
                case "CubeDL":
                    //transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * speed, ForceMode.Impulse);
                    break;
                case "CubeDR":
                    //transform.rotation = Quaternion.AngleAxis(-30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * speed, ForceMode.Impulse);
                    break;
            }
            //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, -1, 0) * speed, ForceMode.Impulse);
            //transform.rotation = Quaternion.AngleAxis(-30, Vector3.right);
            //transform.Translate(new Vector3(-speed * Time.deltaTime, 0, -0.4f));
        }
        else if (transform.name.Contains("CubeL"))
        {
            Color a;
            
            switch (transform.name)
            {
                case "CubeLU":
                    transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * speed, ForceMode.Impulse);
                    break;
                case "CubeLD":
                    transform.rotation = Quaternion.AngleAxis(-30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * speed, ForceMode.Impulse);
                    break;
            }
            //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
            //transform.rotation = Quaternion.AngleAxis(-30, Vector3.right);
            //transform.Translate(new Vector3(speed * Time.deltaTime, 0, -0.4f));
            //transform.Translate(-ran * cubect, -speed * Time.deltaTime, 0);
        }
        else if (transform.name.Contains("CubeR"))
        {
            switch (transform.name)
            {
                case "CubeRU":
                    transform.rotation = Quaternion.AngleAxis(-30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * speed, ForceMode.Impulse);
                    break;
                case "CubeRD":
                    transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * speed, ForceMode.Impulse);
                    break;
            }
            //transform.Translate(new Vector3(0, -speed * Time.deltaTime, -0.4f));
        }
    }
}
