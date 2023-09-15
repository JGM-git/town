using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class MoveController : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private NavMeshAgent agent;
    private Animator anim;
    private PlayerManager playerManager;
    [SerializeField]
    public Transform Spot;
    public LayerMask layerMask;
    
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
        if (playerManager.isDriving) return;
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~layerMask))
            {
                Spot.gameObject.SetActive(true);
                Spot.position = hit.point + Vector3.up * 0.1f;
                SpotAnimation();
                anim.SetBool("isWalking", true);
                if (anim.GetBool("isWalking") && anim.GetBool("isRun")) anim.SetFloat("Blend", 1f);
                else anim.SetFloat("Blend", 0.5f);
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }
        else if (agent.remainingDistance < 0.2f)
        {
            Spot.gameObject.SetActive(false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRun", false);
            anim.SetFloat("Blend", 0);
            agent.speed = 1f;
            agent.isStopped = true;
            agent.ResetPath();
        }

        if (playerManager.stamina <= 1f)
        {
            anim.SetBool("isRun", false);
            agent.speed = 1f;
            anim.SetFloat("Blend", 0.5f);
            return;
        }

        if (!agent.isStopped && transform.position != agent.steeringTarget) Rotate();
    }

    /// <summary>
    /// CUSTOM FUNCTIONS
    /// </summary>

    private void SpotAnimation()
    {
        Spot.gameObject.transform.localScale = Vector3.one * 0.01f;
        Spot.gameObject.transform.DOScale(0.2f, 0.2f);
    }
    
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
        if (anim.GetBool("isWalking"))
        {
            bool isRun = anim.GetBool("isRun");
            float blend = anim.GetFloat("Blend");
            isRun = isRun ? false : true;
            blend = blend == 1 ? 0.5f : 1f;
            anim.SetBool("isRun", isRun);
            anim.SetFloat("Blend", blend);
            agent.speed = blend == 1 ? 3f : 1f;
        }
    }

    public void DriveTest()
    {
        anim.SetTrigger("drive");
    }
}
