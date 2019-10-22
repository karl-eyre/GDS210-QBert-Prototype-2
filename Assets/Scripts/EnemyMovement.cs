using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject wayPoint;
    public GameObject pastLoc;
    public float pastLocDist;

    private float currentTime;
    private int seconds;
    private NavMeshAgent navAgent;
    private int moveTimer;
    private GameObject[] waypoints;
    private float playerDist;

    void Start()
    {

        pastLoc = GameObject.FindGameObjectWithTag("PastLoc");
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        pastLoc.transform.position = transform.position;
        //waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
        //FindWayPoints();

    }

    void Update()
    {

        currentTime = Time.realtimeSinceStartup;
        seconds = Mathf.FloorToInt(currentTime);

        pastLocDist = Vector3.Distance(pastLoc.transform.position, transform.position);

        playerDist = Vector3.Distance(wayPoint.transform.position, transform.position);

        if(pastLocDist > 1.4f)
        {
            moveTimer = seconds += 1;
            pastLoc.transform.position = transform.position;
            navAgent.destination = pastLoc.transform.position;

        }

        if(seconds > moveTimer)
        {

            navAgent.destination = wayPoint.transform.position;

        }

        /*if(playerDist > .5f)
        {

            FindWayPoints();

        }*/

    }

    /*void FindWayPoints()
    {

        wayPoint = waypoints[Random.Range(0, waypoints.Length)];

    }*/

}
