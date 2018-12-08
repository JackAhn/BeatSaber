using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrokenCubeMovement : MonoBehaviour {

    private float speed = 5f;

	// Use this for initialization
	void Start () {
        speed = MusicParser.Instance.Speed;
	}
	
	// Update is called once per frame
	void Update () {
        BrokencubeTranslate();
        if (transform.position.y < 0)
            Destroy(this.gameObject);
	}


    private void BrokencubeTranslate()
    {
        if (transform.name.Equals("CubeUp"))
        {
            /*if (LeftRight == 0)
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * speed, ForceMode.Impulse);
            }
            else
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * speed, ForceMode.Impulse);
            }*/
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 1));
        }
        else if (transform.name.Equals("CubeLeft"))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, -1));
            //transform.Translate(ran * cubect, -speed * Time.deltaTime , 0);
        }
        else if (transform.name.Equals("CubeRight"))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, -1));
            //transform.Translate(-ran * cubect, -speed * Time.deltaTime, 0);
        }
        else if (transform.name.Equals("CubeDown"))
        {
            /*if (LeftRight == 0)
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -1, -1) * speed, ForceMode.Acceleration);
            }
            else
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, -1, -1) * speed, ForceMode.Acceleration);
            }*/
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 1));
        }
    }
}
