using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//게임 종료 전 사용되는 메소드 모음
public class BeforeGameover : MonoBehaviour {

    private float animTime = 2f;
    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    private Image image;

    public void SetGameOver()
    {
        for (int i = 0; i < MusicParser.parsedMusic.Beats.Count; i++)
        {
            GameObject cube = GameObject.Find("Cube" + i);
            if (cube != null) //큐브가 존재하는지 확인
            {
                Destroy(cube); //큐브 삭제
                Vector3 cubepos = cube.gameObject.transform.position;

                //부서진 큐브 생성
                CubeGenerator.Instance.CreateBrokenCube(cubepos.x, cubepos.y, cubepos.z, 
                    (MusicParser.Sight)MusicParser.parsedMusic.Beats[i].Sight, (MusicParser.Hand)MusicParser.parsedMusic.Beats[i].Hand);
            }
        }
        image = GameObject.FindGameObjectWithTag("imgPanel").GetComponent<Image>();
        //StartCoroutine nullreference exception 발생 -> 구현 안 됨
        //StartCoroutine(this.FadeIn());
    }


    IEnumerator FadeIn()
    {
        Color color = image.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animTime;
            color.a = Mathf.Lerp(start, end, time);
            image.color = color;

            yield return null;
        }
    }
}
