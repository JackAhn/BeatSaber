using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    /// <summary>
    /// 유저가 큐브를 자르는 과정 생성된 큐브와 일치한지 확인하기 위한 int형 변수
    /// </summary>
    private int Cubetblr=1; //큐브 상하좌우 (0:상, 1:하, 2:좌, 3:우)
    private int Cubehand; //큐브 잘라야 하는 손의 위치 (0:왼쪽, 1:오른쪽)

    private int Usertblr=0; //유저가 큐브에 들어온 상하좌우 (0:상, 1:하, 2:좌, 3:우)
    private int Userhand; //유저가 큐브 자른 손의 위치 (0:왼쪽, 1:오른쪽)

    private float startobjX; //칼이 들어올 때 X좌표
    private float startobjY; //칼이 들어올 때 Y좌표

    private float endobjX; //칼이 나갈 때 X좌표
    private float endobjY; //칼이 나갈 때 Y좌표

    private int objNum; //큐브 번호
    private MusicParser.Sight objSight; //큐브 자를 위치(상하좌우)
    private MusicParser.Hand objHand; //큐브가 생성된 위치(왼쪽, 오른쪽)

    public GameObject explosion; //폭발 이펙트

    
    public void OnTriggerEnter(Collider other)
    {
        Vector3 a = gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position); //콜라이더 좌표 받아오기 위한 변수 생성

        for(int i = 0; i < MusicParser.parsedMusic.Beats.Count; i++)
        {
            if (i == int.Parse(other.gameObject.name.Replace("Cube", ""))) //생성된 큐브의 "Cube" replace 후 숫자만 가져와서 인덱스와 같은지 확인
            {
                //Debug.Log(i);

                //시작 위치 저장
                startobjX = a.x; 
                startobjY = a.y;
                objSight = (MusicParser.Sight)MusicParser.parsedMusic.Beats[i].Sight; //큐브 자를 방향 저장
                objHand = (MusicParser.Hand)MusicParser.parsedMusic.Beats[i].Hand; //큐브 자를 손 위치 저장
                break;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Cubes")
        {
            Vector3 a = gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

            //트리거(=검)가 나갔을 때 위치 저장
            endobjX = a.x;
            endobjY = a.y;

            //사용자가 자른 위치가 큐브의 자른 위치가 같은지 판단
            bool isCorrect = Checkcubecorrect();
            if ((objHand == MusicParser.Hand.LEFT) && (isCorrect == true))
            {
                GameManager.Instance.ScoreUp(); //스코어 증가
                CubeGenerator.Instance.CreateBrokenCube(endobjX, endobjY, a.z, objSight, objHand); //부서진 큐브 생성
            }
            else if ((objHand == MusicParser.Hand.RIGHT) && (isCorrect == true))
            {
                GameManager.Instance.ScoreUp(); //스코어 증가
                CubeGenerator.Instance.CreateBrokenCube(endobjX, endobjY, a.z, objSight, objHand); //부서진 큐브 생성
            }
            else
            //손과 반대로 쳤거나 자른 방향이 잘못되었다면
            {
                //큐브 제거
                Destroy(other.gameObject);

                //이펙트 생성
                Instantiate(explosion, new Vector3(endobjX, endobjY, a.z), transform.rotation);

                //Life 감소
                GameManager.Instance.LifeDown();

                Debug.Log(GameManager.life);
                //생명력이 0이면
                if(GameManager.life == 0)
                {
                    Debug.Log("game over");
                    //게임 종료 전 각종 이펙트
                    BeforeGameover bg = new BeforeGameover();
                    bg.SetGameOver();
                    //메인으로 이동
                }
            }
        }
    }

    private bool Checkcubecorrect()
    {
        switch (objSight)
        {
            case MusicParser.Sight.UP :
                if (endobjY > startobjY)
                    return true;
                return false;
            case MusicParser.Sight.DOWN:
                if (endobjY < startobjY)
                    return true;
                return false;
            case MusicParser.Sight.LEFT:
                if (endobjX < startobjX)
                    return true;
                return false;
            case MusicParser.Sight.RIGHT:
                if (endobjX > startobjX)
                    return true;
                return false;
        }
        return false;
    }
}
