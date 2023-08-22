using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookCamera : MonoBehaviour
{
    private Transform camTransform;
    private Vector3 originalScale;

    void Start()
    {
//        GameObject ParentObject = transform.parent.gameObject;
//        transform.SetParent(ParentObject.transform, false);
        originalScale = transform.localScale;
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        //transform.localScale = originalScale;
        transform.LookAt(camTransform);
    }
}
