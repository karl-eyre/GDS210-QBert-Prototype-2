using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectorMovement : MonoBehaviour
{
    public Renderer infectorColour;
    public float spinSpeed;
    public float spinMultiplyer = 0.1f;

    void Start()
    {
        infectorColour = GetComponent<Renderer>();
    }

    void Update()
    {
        spinSpeed = spinSpeed + spinMultiplyer;
        infectorColour.material.SetTextureOffset("_MainTex", new Vector2(spinSpeed, 0));
    }
}
