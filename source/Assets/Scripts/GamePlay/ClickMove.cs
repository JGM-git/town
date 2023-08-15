using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    [SerializeField]
    private float moveLimit = 0.3f;

    public Transform Spot;
    
    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        anim = GetComponent<Animator>();
        SetAgentShape();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (Vector3.Distance(hit.point, transform.position) < moveLimit)
                    return;
                Spot.gameObject.SetActive(true);
                Spot.position = hit.point + Vector3.up * 0.1f;
                anim.SetBool("isWalking", true);
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }
        else if (agent.remainingDistance < 0.4f)
        {
            Spot.gameObject.SetActive(false);
            anim.SetBool("isWalking", false);
            agent.isStopped = true;
            agent.ResetPath();
        }
        
        if(!agent.isStopped && transform.position != agent.steeringTarget) Rotate();
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

    private void Rotate()
    {
        Vector2 forward = new Vector2(transform.position.z, transform.position.x);
        Vector2 steeringTarget = new Vector2(agent.steeringTarget.z, agent.steeringTarget.x);
        Debug.LogFormat("STEERING TARGET : {0}", steeringTarget);
    
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    
        transform.localEulerAngles = Vector3.up * angle;
    }
}
