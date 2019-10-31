using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasePlayer : MonoBehaviour
{

    public GameObject wayPoint;
    public GameObject pastLoc;
    public float pastLocDist;
    public GameObject goal;

    private float currentTime;

    private NavMeshAgent navAgent;
    private float moveTimer;

    private float playerDist;

    void Start()
    {

        //pastLoc = GameObject.FindGameObjectWithTag("PastLoc");
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        pastLoc.transform.position = transform.position;

    }

    void Update()
    {

        currentTime = Time.realtimeSinceStartup;


        pastLocDist = Vector3.Distance(pastLoc.transform.position, transform.position);

        playerDist = Vector3.Distance(wayPoint.transform.position, transform.position);

        if (pastLocDist > 1.4f)
        {

            pastLoc.transform.position = transform.position;
            navAgent.destination = pastLoc.transform.position;
            moveTimer = currentTime += 1;

        }

        if (currentTime > moveTimer)
        {

            navAgent.destination = wayPoint.transform.position;

            goal.transform.position = wayPoint.transform.position;

        }

        if (playerDist < .1f)
        {

            Debug.Log("ONPLAYER");

        }

    }

}