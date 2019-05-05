using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    public GameObject explosion; //폭발 이펙트
    private float speed;

    // Use this for initialization
    void Start () {
        speed = MusicParser.Instance.Speed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, -speed * Time.deltaTime);
        if(transform.position.z <= 0.2f){
            //Bad 이미지 띄우기
            ShowImage.Instance.setImage(1);

            //Life 감소
            GameManager.Instance.LifeDown();

            //이펙트 생성
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0.2f), transform.rotation);
            Destroy(this.gameObject);

            if (GameManager.life == 0)
            {
                //게임 종료 전 각종 이펙트
                BeforeGameover bg = new BeforeGameover();
                bg.SetGameOver();
            }
        }
	}
}
