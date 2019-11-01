using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] CubesColours;
    public int Score;
    public Material colourToLookFor;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            CubesColours = GameObject.FindGameObjectsWithTag("Plane");
        }
        
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            CountScore();

            if (Score == 0)
            {
                print("YOU WIN THE GAME!!!");
                this.GetComponent<SceneButtons>().SceneChangeYouWin();
            }
        }
                   
    }

    void CountScore()
    {
        int x = 0;

        foreach (GameObject cube in CubesColours)
        {
            ColourChange Currentstate = cube.GetComponent<ColourChange>();
            //if(cube.GetComponent<MeshRenderer>().material != Currentstate.thirdMat)
            if (cube.GetComponent<MeshRenderer>().material.name != "Third_MAT (Instance)")
            {
                x = x + 1;
                print(cube.GetComponent<MeshRenderer>().material.name);
            }
        }

        Score = x;

        print(x);
    }

}
