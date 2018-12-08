using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class MusicParser : MonoBehaviour {



    // Use this for initialization
    private void Start()
    {
        PlayMusic("music1.json");
    }

    public static MusicParser Instance;

    private void Awake()
    {
        Instance = this;
    }

    private int curIndex = 0;
    public static Music parsedMusic = null;

    public float Speed = 25;

    public void PlayMusic(string filename){
        parsedMusic = ParseMusic(filename);
        CreateNode();
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CreateNode();
    }

    private void CreateNode(){
        //Life가 0이면
        if (GameManager.life == 0)
            return; //생성 종료
        Beat curBeat = parsedMusic.Beats[curIndex];
        CubeGenerator.Instance.CreateCube(curIndex, curBeat.X, curBeat.Y, (Sight)curBeat.Sight, (Hand)curBeat.Hand);
        curIndex++;
        if(curIndex == parsedMusic.Beats.Count){ return; } // Music END
        StartCoroutine(Wait(curBeat.Time/1000));
    }

    public class Music{
        public string Title { get; set; }
        public string Artist { get; set; }
        public int BPM { get; set; }
        public int Difficulty { get; set; }
        public int Speed { get; set; }
        public string MusicSource { get; set; }
        public List<Beat> Beats { get; set; }
    }

    public class Beat{
        public int X { get; set; }
        public int Y { get; set; }
        public int Time { get; set; }
        public int Hand { get; set; }
        public int Sight { get; set; }
    }

    public Music ParseMusic(string filename)
    {
        string json = System.IO.File.ReadAllText("Assets/Musics/" + filename);
        var parsedJson = JSON.Parse(json);

        List<Beat> listBeat = new List<Beat>();
        JSONArray beatArray = parsedJson["Beat"].AsArray;


        foreach(JSONNode beat in beatArray){
            listBeat.Add(new Beat()
            {
                X = beat["X"].AsInt,
                Y = beat["Y"].AsInt,
                Time = beat["Time"].AsInt,
                Hand = beat["Hand"].AsInt,
                Sight = beat["Sight"].AsInt
            });
        }

        return new Music()
        {
            Title = parsedJson["Title"].Value,
            Artist = parsedJson["Artist"].Value,
            BPM = parsedJson["BPM"].AsInt,
            Difficulty = parsedJson["Difficulty"].AsInt,
            Speed = parsedJson["Speed"].AsInt,
            MusicSource = parsedJson["MusicSource"].Value,

            Beats = listBeat
        };
    }
    public enum Difficulty
    {
        NORMAL=0, HARD=1
    }
    public enum Sight
    {
        LEFT = 0, RIGHT = 1, UP = 2, DOWN = 3
    }
    public enum Hand
    {
        LEFT = 0, RIGHT = 1
    }
}
