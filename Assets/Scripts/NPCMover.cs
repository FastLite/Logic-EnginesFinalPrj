using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NPCMover : MonoBehaviour
{
    NavMeshAgent agent;
    public List<Transform> wayPoints;
    public int destinationNumber = 0;
    public float distanceCheck = 0.1f;
    private float distance;


    void Start()
    {
        destinationNumber = Random.Range(0, wayPoints.Count);
        agent = GetComponent<NavMeshAgent>();
        agent.destination = wayPoints[destinationNumber].position;
    }


    void Update()
    {
        // go to travel location x
        // If you are at destination. change to new destination
        var position = transform.position;
        distance = Vector3.Distance(wayPoints[destinationNumber].position, position);
         
          if (distance < distanceCheck )
        {
            GoToNewDestination();
            
        }
    }
    private void GoToNewDestination()
    {
        destinationNumber = Random.Range(0, wayPoints.Count);
        agent.destination = wayPoints[destinationNumber].position;
       
    }
}