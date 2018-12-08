using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

    public static CubeGenerator Instance;
    public GameObject blueCube;
    public GameObject redCube;
    public GameObject BrokenBlueCube1;
    public GameObject BrokenBlueCube2;
    public GameObject BrokenRedCube1;
    public GameObject BrokenRedCube2;

    private void Awake()
    {
        Instance = this;
    }

    /** 
     * param name="ind" cubeno (MusicParser.parsedMusic.Beats.Count)
     * param name="x" range 0~10
     * param name="y" range 0~5
     * param name="s" LEFT, RIGHT, UP, DOWN
     * param name="h" LEFT, RIGHT
     */
    public void CreateCube(int ind, float x, float y, MusicParser.Sight s, MusicParser.Hand h)
    {
        GameObject obj = Instantiate(h == MusicParser.Hand.LEFT ? blueCube : redCube, new Vector3(x - 5, y + 2.5f, 200), GetQuaternion(s));
        obj.name = "Cube" + ind;
    }

    public void CreateBrokenCube(float x, float y, float z, MusicParser.Sight s, MusicParser.Hand h)
    {
        GameObject obj1, obj2;
        if (s == MusicParser.Sight.UP || s == MusicParser.Sight.DOWN)
        {
            obj1 = Instantiate(h == MusicParser.Hand.LEFT ? BrokenBlueCube2 : BrokenRedCube2, new Vector3(x, y, z), Quaternion.EulerAngles(new Vector3(0, 0)));
            obj1.name = "CubeLeft";
            obj2 = Instantiate(h == MusicParser.Hand.LEFT ? BrokenBlueCube2 : BrokenRedCube2, new Vector3(x + 2, y, z), Quaternion.EulerAngles(new Vector3(0, 0)));
            obj2.name = "CubeRight";
        }
        else if (s == MusicParser.Sight.LEFT || s == MusicParser.Sight.RIGHT)
        {
            obj1 = Instantiate(h == MusicParser.Hand.LEFT ? BrokenBlueCube1 : BrokenRedCube1, new Vector3(x, y, z), Quaternion.EulerAngles(new Vector3(0, 10)));
            obj1.name = "CubeUp";
            obj2 = Instantiate(h == MusicParser.Hand.LEFT ? BrokenBlueCube1 : BrokenRedCube1, new Vector3(x, y - 2, z), Quaternion.EulerAngles(new Vector3(0, -10)));
            obj2.name = "CubeDown";
        }
    }

    private Quaternion GetQuaternion(MusicParser.Sight s)
    {
        Quaternion quaternion = Quaternion.identity;
        switch (s)
        {
            case MusicParser.Sight.LEFT:
                quaternion.eulerAngles = new Vector3(0, 0, 180);
                break;

            case MusicParser.Sight.RIGHT:
                quaternion.eulerAngles = new Vector3(0, 0, 0);
                break;

            case MusicParser.Sight.UP:
                quaternion.eulerAngles = new Vector3(0, 0, 90);
                break;

            case MusicParser.Sight.DOWN:
                quaternion.eulerAngles = new Vector3(0, 0, 270);
                break;
        }
        return quaternion;
    }
}