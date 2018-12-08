using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public static int Score = 0;
    public static int life = 5;

    public Text scoreText;

    private void Awake()
    {
        Instance = this;
    }
	
	void Update () {
        scoreText.text = "Score: " + Score.ToString("0");
	}

    //점수 증가
    public void ScoreUp()
    {
        Score++;
    }

    //Life 감소
    public void LifeDown()
    {
        life--;
    }
}
