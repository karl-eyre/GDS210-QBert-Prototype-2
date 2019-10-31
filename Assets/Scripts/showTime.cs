using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showTime : MonoBehaviour
{
    

    public int seconds;
    float secondsToCovert = 0.0f;
    private Text clockTimer;

    public int triggerActionTimer = 0;
    public GameObject player;

    public GameObject[] infectCube;

    public int timeToInfect;
    public int timeBetweenInfect;

    public int endTime;

    //Show the time per second as text
    void Start()
    {
        infectCube = GameObject.FindGameObjectsWithTag("Cube");
        clockTimer = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        secondsToCovert = Time.realtimeSinceStartup;
        seconds =  Mathf.FloorToInt(secondsToCovert);
        clockTimer.text = "Seconds: " + seconds.ToString();

        if (seconds > triggerActionTimer)
        {
            player.GetComponent<PlayerMovement>().TriggerSecond();
            triggerActionTimer = seconds;
            //print(seconds);
        }

        if (seconds > (timeToInfect + timeBetweenInfect))
        {
            infectCubes();
            timeToInfect = seconds - 1;
        }

        if (endTime < seconds)
        {
            print("YOU LOSE THE GAME");
        }
    }

    void infectCubes()
    {
        foreach (GameObject cube in infectCube)
        {
            cube.GetComponent<CubeColourChange>().infect();
        }
    }

}

