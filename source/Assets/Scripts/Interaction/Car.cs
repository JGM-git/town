using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Car : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public Transform Seat;
    private UIManager ui;
    
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }

    public void GetOn(Transform target)
    {
        target.position = Seat.position;
        target.forward = Seat.forward;
        target.SetParent(transform);
        ResetAgentPath(target);
        ChangeToDriveAnim(target);
        target.GetComponent<PlayerManager>().isDriving = true;
        ui.ManageSpeedText();
    }

    public void GetOff(Transform target)
    {
        target.SetParent(null);
        target.position = Seat.position + Vector3.left * 2f;
        ChangeToDriveAnim(target);
        target.GetComponent<PlayerManager>().isDriving = false;
        ui.ManageSpeedText();
    }

    private void ChangeToDriveAnim(Transform target)
    {
        Animator anim = target.GetComponent<Animator>();
        bool drivingState = anim.GetBool("isDriving");
        anim.SetBool("isDriving", !drivingState);
    }

    private void ResetAgentPath(Transform target)
    {
        target.GetComponent<NavMeshAgent>().ResetPath();
    }
}
