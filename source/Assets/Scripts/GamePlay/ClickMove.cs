using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Animator anim;
    
    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        SetAgentShape();
    }

    void Update()
    {
        Debug.Log(agent.isStopped);
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.LogFormat("{0} - {1}", hit.transform.name, hit.point);
                //anim.SetBool("isWalking", true);
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance < 0.1f)
        {
            //anim.SetBool("isWalking", false);
            agent.isStopped = true;
        }
    }

    /// <summary>
    /// CUSTOM FUNCTIONS
    /// </summary>
    
    private void SetAgentShape()
    {
        SkinnedMeshRenderer mesh = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        Vector3 meshBox = mesh.sharedMesh.bounds.size;
        float maxRadius = Mathf.Max(meshBox.x, meshBox.z) / 2f;
        float maxHeight = meshBox.y;
        agent.radius = maxRadius;
        agent.height = maxHeight;
    }
}
