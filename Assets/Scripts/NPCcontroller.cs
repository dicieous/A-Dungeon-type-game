using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    public float patroltime = 10f;
    public float aggroagent = 10f;
    public Transform[] waypoints;

    private int Index;
    private float speed, agentspeed;
    private Transform player;

    //private Animator anim;
    private NavMeshAgent agent;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
       agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agentspeed = agent.speed;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Index = Random.Range(0, waypoints.Length);
        InvokeRepeating("Tick", 0, 0.5f);
        if(waypoints.Length > 0)
        {
            InvokeRepeating("Patrol",0, patroltime);
        }
    }

    void Patrol()
    {
        Index = Index == waypoints.Length - 1 ? 0 : Index + 1;
    }

    void Tick()
    {
        agent.destination = waypoints[Index].position;
    }

}
