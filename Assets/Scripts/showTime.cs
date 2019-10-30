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

    //Show the time per second as text
    void Start()
    {
        clockTimer = this.GetComponent<Text>();
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
    }
}
