using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private NavMeshAgent agent;
    private Animator anim;
    private PlayerManager playerManager;
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
        playerManager = GetComponent<PlayerManager>();
        SetAgentShape();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("MOUSE RIGHT CLICK !!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (Vector3.Distance(hit.point, transform.position) < moveLimit)
                    return;
                Spot.gameObject.SetActive(true);
                Spot.position = hit.point + Vector3.up * 0.1f;
                anim.SetBool("isWalking", true);
                anim.SetFloat("Blend", 0.5f);
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }
        else if (agent.remainingDistance < 0.4f)
        {
            Debug.Log("remainingDistance < 0.4f !!");
            Spot.gameObject.SetActive(false);
            anim.SetBool("isWalking", false);
            anim.SetFloat("Blend", 0);
            agent.speed = 1f;
            agent.isStopped = true;
            agent.ResetPath();
        }
        
        if(!agent.isStopped && transform.position != agent.steeringTarget) Rotate();

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("isStopped : " + agent.isStopped);
            Debug.Log("destination : " + agent.destination);
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

    private void Rotate()
    {
        Vector2 forward = new Vector2(transform.position.z, transform.position.x);
        Vector2 steeringTarget = new Vector2(agent.steeringTarget.z, agent.steeringTarget.x);
    
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    
        transform.localEulerAngles = Vector3.up * angle;
    }

    public void Run()
    {
        if (playerManager.stamina <= 0f) return;

        if (anim.GetBool("isWalking"))
        {
            float blend = anim.GetFloat("Blend");
            blend = blend == 1 ? 0.5f : 1f;
            anim.SetFloat("Blend", blend);
            agent.speed = blend == 1 ? 3f : 1f;
        }
    }
}
