using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    
    public enum Colour{ First, Second, Third};
    public GameObject[] adjacentBlocks;
    public Material firstMat;
    public Material secondMat;
    public Material thirdMat;
    public float infectTime;

    private Colour currentColour = Colour.First;
    private float currentTime;
    private float turnTime;
    private MeshRenderer meshR;

    void Start()
    {

        meshR = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        meshR.material = firstMat;

    }

    
    void Update()
    {

        currentTime = Time.timeSinceLevelLoad;
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
        Debug.Log("Enter");
        if(other.gameObject.CompareTag("Player") == true)
        {

            Change();

        }

    }

    public void Change()
    {

        if (currentColour == Colour.First)
        {
            Debug.Log("First");
            meshR.material = secondMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Second;

        }

        else if (currentColour == Colour.Second)
        {
            Debug.Log("Second");
            meshR.material = thirdMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Third;

        }

        else if (currentColour == Colour.Third)
        {
            Debug.Log("Third");


        }

    }

    public void Infected()
    {

        if (currentColour == Colour.First)
        {
            Debug.Log("First");
            meshR.material = firstMat;

        }

        else if (currentColour == Colour.Second)
        {
            Debug.Log("Second");
            meshR.material = firstMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.First;

        }

        else if (currentColour == Colour.Third)
        {
            Debug.Log("Third");
            meshR.material = secondMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.Second;

        }

    }

    void infect()
    {

        if (currentColour == Colour.First)
        {
            Debug.Log("First");
            meshR.material = firstMat;

        }

        else if (currentColour == Colour.Second)
        {
            Debug.Log("Second");
            meshR.material = firstMat;

            turnTime = currentTime += infectTime;

            currentColour = Colour.First;

        }

        else if (currentColour == Colour.Third)
        {
            Debug.Log("Third");
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


