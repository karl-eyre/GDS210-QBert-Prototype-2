using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{

    // eneum of what stage of the infection the cube is in
    public enum Colour{ First, Second, Third};
    // the cubes it should infect
    public GameObject[] adjacentBlocks;
    // the materials it will change to in the different stages
    public Material firstMat;
    public Material secondMat;
    public Material thirdMat;
    // how many seconsd untill it infects the adjacent blocks
    public float infectTime;

    // current state aka current stage of the infection
    private Colour currentColour = Colour.First;
    // the current time since the scene was loaded
    private float currentTime;
    // at waht time it will infect
    private float turnTime;
    // the meshrenderer for the colour change
    private MeshRenderer meshR;

    void Start()
    {
        // gets the mesh renderer and the sets the first material
        meshR = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        meshR.material = firstMat;
        adjacentBlocks[0] = gameObject.GetComponent<CubeColourChange>().downRightBox;
        adjacentBlocks[1] = gameObject.GetComponent<CubeColourChange>().upLeftBox;
        adjacentBlocks[2] = gameObject.GetComponent<CubeColourChange>().upRightBox;
        adjacentBlocks[3] = gameObject.GetComponent<CubeColourChange>().downLeftBox;

    }

    
    void Update()
    {
        // gets the current time
        currentTime = Time.timeSinceLevelLoad;
        // if its not in the first stage of the infection and the current time is larger the the turn time it runns the infect function
        if(currentColour != Colour.First)
        {

            if (currentTime > turnTime)
            {

                infect();

            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        // when the player enters the trigger it runns 
        //Debug.Log("Enter");
        if(other.gameObject.CompareTag("Player") == true)
        {

            Change();

        }

        if (other.gameObject.CompareTag("InfectorEnemy") == true)
        {

            Infected();

        }

    }

    public void Change()
    {
        // depending on the currnet state it changes to teh nex material and adds time to the turn timer and changes the state to the next one
        if (currentColour == Colour.First)
        {
            //Debug.Log("First");
            meshR.material = secondMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Second;

        }

        else if (currentColour == Colour.Second)
        {
            //Debug.Log("Second");
            meshR.material = thirdMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Third;

        }

        else if (currentColour == Colour.Third)
        {
            //Debug.Log("Third");



        }

    }
    // like the change function but in reverse but this one is called by another cube
    public void Infected()
    {

        if (currentColour == Colour.First)
        {
            //Debug.Log("First");
            meshR.material = firstMat;

        }

        else if (currentColour == Colour.Second)
        {
            //Debug.Log("Second");
            meshR.material = firstMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.First;

        }

        else if (currentColour == Colour.Third)
        {
            //Debug.Log("Third");
            meshR.material = secondMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Second;

        }

    }
    // the same as the infected function except its called by the this game object and runnes the infected function on the adjacent blocks
    void infect()
    {

        if (currentColour == Colour.First)
        {
            //Debug.Log("First");
            meshR.material = firstMat;

        }

        else if (currentColour == Colour.Second)
        {
            //Debug.Log("Second");
            meshR.material = firstMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.First;

        }

        else if (currentColour == Colour.Third)
        {
            //Debug.Log("Third");
            meshR.material = secondMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Second;

        }

        foreach (GameObject block in adjacentBlocks)
        {

            block.GetComponent<ColourChange>().Infected();

        }

    }

}


