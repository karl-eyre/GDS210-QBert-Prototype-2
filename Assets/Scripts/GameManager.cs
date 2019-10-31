using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] cubes;
    void Start()
    {

        cubes = GameObject.FindGameObjectsWithTag("Cubes");

    }

    
    void Update()
    {
        


    }

    public void WinCheck()
    {

        foreach (GameObject cube in cubes)
        {



        }

    }

}
