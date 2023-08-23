using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        detected.GetComponent<PrintInteractable>().GenerateIcon();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!InteractableTag.Contains(other.tag)) return;
        detected.GetComponent<PrintInteractable>().DestroyIcon();
        detected = null;
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