using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navAgent;

    //position for player to move
    public GameObject moveSqaure;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //control input for player with numpad 1,2,4 & 5

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("Keypad1");
            SetPosition(new Vector3(1, -1, 0));
            
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Keypad2");
            SetPosition(new Vector3(0, -1, 1));
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("Keypad4");
            SetPosition(new Vector3(0, 1, -1));
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Debug.Log("Keypad5");
            SetPosition(new Vector3(-1, 1, 0));
            //moveSqaure.transform.position = this.gameObject.transform.position + new Vector3(-1, 1, 0);
        }   
    }

    public void SetPosition(Vector3 x)
    {
        //update move location based on player position
        moveSqaure.transform.position = this.gameObject.transform.position + (x);
    }

    //make movement happen each second of the game
    public void TriggerSecond()
    {
     navAgent.SetDestination(moveSqaure.transform.position);
    }
   
}
