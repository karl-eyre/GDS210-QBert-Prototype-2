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

    public GameObject tile;

    public Material[] colours;

    public int colourChoice;

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
        tile.GetComponent<MeshRenderer>().material = colours[colourChoice + x];
        //this.gameObject.GetComponentInChildren<MeshRenderer>().material = colours[colourChoice + x];
    }
}
