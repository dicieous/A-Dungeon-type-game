using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //private Animator anime;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake ()
    {
        //anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
}
