using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private bool isOpened = false;
    
    public void ManageDoor()
    {
        isOpened = !isOpened;
        transform.DORotate((isOpened ? Vector3.up * 90f : Vector3.zero), 1f);
    }

    private void Start()
    {
        
    }
}
