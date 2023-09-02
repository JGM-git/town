using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public Transform Seat;
    
    void Start()
    {
        
    }

    public void GetOn(Transform target)
    {
        target.position = Seat.position;
        target.forward = Seat.forward;
        target.SetParent(transform);
        ChangeToDriveAnim(target);
    }

    private void ChangeToDriveAnim(Transform target)
    {
        Animator anim = target.GetComponent<Animator>();
        anim.SetBool("isDriving", true);
    }
}
