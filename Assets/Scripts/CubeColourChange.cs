using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColourChange : MonoBehaviour
{
    //provide locations for the surounding boxs
    public GameObject upRightBox;
    public GameObject upLeftBox;
    public GameObject downLeftBox;
    public GameObject downRightBox;
    public Material firstMat;
    public Material secondMat;
    public Material thirdMat;
    public Material fourthMat;
    public enum Colour { First, Second, Third, Fourth };
    public Colour currentColour = Colour.First;
    public GameObject firstParticle;
    public GameObject secondParticle;
    public GameObject thirdParticle;

    public GameObject firstToEnter;
    private MeshRenderer meshR;
    //target the matirials we need and create an array to hold them, karl
    /*public Material aqua;
    public Material navyBlue;
    public Material pink;
    public Material infectedTile1;
    public Material infectedTile2;

    //target the plane changing colour
    public GameObject tile;

    //store colours in a list
    public Material[] colours;

    //store current colour selection
    public int colourChoice;

    //store whether the plane needs to change colour
    public bool needToChangeColour = true;

    //Store wether tile is infected
    public bool isTileInfected = false;
    public bool colourFlickChoice = true;*/

    // Start is called before the first frame update
    void Start()
    {
        /* tile = this.gameObject.transform.Find("Plane").gameObject;
         colours = new Material[] { aqua, navyBlue, pink, infectedTile1, infectedTile2 };
         tile.GetComponent<MeshRenderer>().material = colours[colourChoice];*/

        meshR = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        meshR.material = firstMat;

    }

    // Update is called once per frame
    void Update()
    {
        if(firstToEnter != null)
        {

            if (Vector3.Distance(gameObject.transform.GetChild(1).transform.position, firstToEnter.transform.position) > 1)
            {

                firstToEnter = null;

            }

        }
        

        //if firstToEnter distance > ???? 
            //firstToEnter = null;
    }

    // on collision change the colour to the lower colour
    /*public void ChangeSquareColour(int x)
    {
        //dont change colour if above or bello array range
        if (needToChangeColour == true && colourChoice + x > -1 && colourChoice + x < colours.Length + 1)
        {
            colourChoice = colourChoice + x;
            needToChangeColour = false;
            tile.GetComponent<MeshRenderer>().material = colours[colourChoice];
            print("triggered");
        }
        // & (colourChoice + x) <= 0 || (colourChoice + x) >= 5
        //this.gameObject.GetComponentInChildren<MeshRenderer>().material = colours[colourChoice + x];
    }*/

    //function for when a tile is infected
    /*public void infectedTile()
    {
        if(isTileInfected == true)
        {
            if (colourFlickChoice == true)
            {
                tile.GetComponent<MeshRenderer>().material = colours[3];
                colourFlickChoice = false;
            }
            else if (colourFlickChoice == false)
            {
                tile.GetComponent<MeshRenderer>().material = colours[4];
                colourFlickChoice = true;
            }
        }
        
    }*/

    void OnTriggerEnter(Collider other)
    {
        // when the player enters the trigger it runns 
        //Debug.Log("Enter");

        if (firstToEnter == null)
        {
            firstToEnter = other.gameObject;
            if (other.gameObject.CompareTag("Player") == true)
            {

                Change();

            }

            //Debug.Log(other.tag);

            if (other.gameObject.CompareTag("InfectorEnemy") == true)
            {
                Debug.Log("INFECTED");
                Infected();

            }

        }

    }



    public void Change()
    {
        // depending on the currnet state it changes to the next material and adds time to the turn timer and changes the state to the next one

        if (currentColour == Colour.Fourth)
        {

            meshR.material = firstMat;

            currentColour = Colour.First;

        }

        if (currentColour == Colour.First)
        {
            //Debug.Log("First");
            meshR.material = secondMat;
            Instantiate(secondParticle, transform);
            //turnTime = currentTime += infectTime;

            currentColour = Colour.Second;

        }

        else if (currentColour == Colour.Second)
        {
            //Debug.Log("Second");
            meshR.material = thirdMat;
            Instantiate(thirdParticle, transform);
            //turnTime = currentTime += infectTime;

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

        meshR.material = fourthMat;

        currentColour = Colour.Fourth;

        //turnTime = currentTime += infectTime;

    }
    // the same as the infected function except its called by the this game object and runnes the infected function on the adjacent blocks
    public void infect()
    {

        if (currentColour == Colour.Fourth)
        {

            if(upRightBox != null)
            {

                upRightBox.GetComponent<CubeColourChange>().meshR.material = upRightBox.GetComponent<CubeColourChange>().fourthMat;
                upRightBox.GetComponent<CubeColourChange>().currentColour = Colour.Fourth;

            }

            if(upLeftBox != null)
            {

                upLeftBox.GetComponent<CubeColourChange>().meshR.material = upLeftBox.GetComponent<CubeColourChange>().fourthMat;
                upLeftBox.GetComponent<CubeColourChange>().currentColour = Colour.Fourth;

            }

            if(downLeftBox != null)
            {

                downLeftBox.GetComponent<CubeColourChange>().meshR.material = downLeftBox.GetComponent<CubeColourChange>().fourthMat;
                downLeftBox.GetComponent<CubeColourChange>().currentColour = Colour.Fourth;

            }

            if(downRightBox != null)
            {

                downRightBox.GetComponent<CubeColourChange>().meshR.material = downRightBox.GetComponent<CubeColourChange>().fourthMat;
                downRightBox.GetComponent<CubeColourChange>().currentColour = Colour.Fourth;

            }
            /*foreach (GameObject block in adjacentBlocks)
            {

                //block.GetComponent<ColourChange>().Infected();
                block.GetComponent<ColourChange>().meshR.material = block.GetComponent<ColourChange>().fourthMat;

                block.GetComponent<ColourChange>().currentColour = Colour.Fourth;

            }*/

        }

    }

}
