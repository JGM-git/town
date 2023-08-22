using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public Collider detected;
    public List<String> InteractableTag;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!InteractableTag.Contains(other.tag)) return;
        detected = other;
    }

    public void DetectAction()
    {
        if (detected == null) return;
        
        if (detected.tag == "Door")
        {
            detected.GetComponent<Door>().ManageDoor();
        }
    }
}