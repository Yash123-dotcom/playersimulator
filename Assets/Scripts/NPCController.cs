using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    public float detectionrange = 5f;
    public float fleerange = 2f;

    private NavMeshAgent agent;
    private int currentwaypointindex = 0; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance < fleerange)
        {
            Vector3 fleeDirection = (transform.position - player.position).normalized;
            agent.SetDestination(transform.position + fleeDirection * 3f);
        }
        
        else if(distance < detectionrange)
        {
            agent.SetDestination(player.position);
        }
    }

    void Gotonextwaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentwaypointindex].position);
        currentwaypointindex = (currentwaypointindex + 1) % waypoints.Length;

    }
}
