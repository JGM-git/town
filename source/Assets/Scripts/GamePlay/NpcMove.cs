using Kawaiiju;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMove : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private Animator anim;
    Vector3 randomDt = new Vector3 (69.5f, 0, -23.5f);
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(randomDt);
        anim.SetFloat("Blend", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}

//(39.5, 0, 31.5) & (59.5, 0, 66.5) & (69.5, 0, -23.5) & (69.5, 0 , -63.5)