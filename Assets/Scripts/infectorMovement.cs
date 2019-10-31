using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectorMovement : MonoBehaviour
{
    public Renderer infectorColour;
    //vaibles to hold. Current offset, Multiplyer of offset & addition of multiplyer for spin up. 
    public float spinSpeed;
    public float spinMultiplyer = 0.1f;
    public float spinUpMultiplyerAddition;

    //get time from show time script
    public GameObject timer;

    public bool spinUpAndInfect = true;
    public int timeToWaitBeforeSpinUp;
    public int timeToSpin;

    void Start()
    {
        infectorColour = GetComponent<Renderer>();
    }

    void Update()
    {
        
        SpinUpOrDown();

        //tell the infect when it is spinning fast enough to infect tiles
        if (spinMultiplyer >= 0.4f && spinUpAndInfect == true)
        {
            this.tag = "InfectorEnemy";
        }

        if (spinMultiplyer < 0.4f)
        {
            this.tag = "Untagged";
        }

        //the the infect when to cool down
        if (spinMultiplyer > 0.5f)
        {
            spinUpAndInfect = false; 
        }

        //Create rotate by adding to offset
        spinSpeed = spinSpeed + spinMultiplyer;
        infectorColour.material.SetTextureOffset("_MainTex", new Vector2(spinSpeed, 0));

        //Start spin timmer + reset
        if (timer.GetComponent<showTime>().seconds > timeToWaitBeforeSpinUp)
        {
            spinUpAndInfect = true;
            timeToWaitBeforeSpinUp = timer.GetComponent<showTime>().seconds + 20;
        } 
    }

    //spin up or down based on status
    void SpinUpOrDown()
    {
        if (spinUpAndInfect == true && spinMultiplyer < 0.51f)
        {
            spinMultiplyer = spinMultiplyer + spinUpMultiplyerAddition;
        }

        if (spinUpAndInfect == false && spinMultiplyer > 0.0f)
        {
            spinMultiplyer = spinMultiplyer + (spinUpMultiplyerAddition * -1);
        }
    }

    public void TurnOnInfector()
    {
        spinUpAndInfect = !spinUpAndInfect;
    } 

}
