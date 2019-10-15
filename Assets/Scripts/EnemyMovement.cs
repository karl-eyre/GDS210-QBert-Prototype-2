using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject wayPoint;

    private NavMeshAgent navAgent;

    void Start()
    {

        navAgent = gameObject.GetComponent<NavMeshAgent>();
        Debug.Log(navAgent.destination);

    }

    void Update()
    {
        
        if(navAgent.destination != wayPoint.transform.position)
        {
            Debug.Log("Target");
            navAgent.SetDestination(wayPoint.transform.position);

        }

    }
}
