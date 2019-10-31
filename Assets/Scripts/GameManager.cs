using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] CubesColours;
    public int Score;

    void Start()
    {
        CubesColours = GameObject.FindGameObjectsWithTag("Cube");
    }

    
    void Update()
    {
        if (Score == 0)
        {
            print("YOU WIN THE GAME!!!");
        }
    }

    void CountScore()
    {
        int x = 0;

        foreach (GameObject cube in CubesColours)
        {
            ColourChange Currentstate = cube.GetComponent<ColourChange>();
            if(cube.GetComponent<MeshRenderer>().material != Currentstate.thirdMat)
            {
                x = x + 1;
            }
        }

        Score = x;

    }

}
