using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectorMovement : MonoBehaviour
{
    public Renderer infectorColour;
    public float spinSpeed;
    public float spinMultiplyer = 0.1f;

    public float spinUpMultiplyerAddition;

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

        if (spinMultiplyer >= 0.4f && spinUpAndInfect == true)
        {
            this.tag = "InfectorEnemy";
        }

        if (spinMultiplyer < 0.4f)
        {
            this.tag = "Untagged";
        }

        if (spinMultiplyer > 0.5f)
        {
            spinUpAndInfect = false; 
        }

        spinSpeed = spinSpeed + spinMultiplyer;
        infectorColour.material.SetTextureOffset("_MainTex", new Vector2(spinSpeed, 0));

        if (timer.GetComponent<showTime>().seconds > timeToWaitBeforeSpinUp)
        {
            spinUpAndInfect = true;
            timeToWaitBeforeSpinUp = timer.GetComponent<showTime>().seconds + 20;
        } 
    }

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
