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

    //target the matirials we need and create an array to hold them, karl
    public Material aqua;
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
    public bool colourFlickChoice = true;

    // Start is called before the first frame update
    void Start()
    {
        tile = this.gameObject.transform.Find("Plane").gameObject;
        colours = new Material[] { aqua, navyBlue, pink, infectedTile1, infectedTile2 };
        tile.GetComponent<MeshRenderer>().material = colours[colourChoice];
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    // on collision change the colour to the lower colour
    public void ChangeSquareColour(int x)
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
    }

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
        
    }
    */
}
