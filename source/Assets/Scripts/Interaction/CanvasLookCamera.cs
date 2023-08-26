using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLookCamera : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private Canvas canvas;
    private RectTransform iconRect;
    private RectTransform rect;
    private Vector3 centerPos;
    private MeshRenderer renderer;
    
    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    void Start()
    {
        canvas = GetComponent<Canvas>();
        iconRect = transform.GetChild(0).GetComponent<RectTransform>();
        renderer = transform.parent.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        centerPos = renderer.bounds.center;
    }

    void LateUpdate()
    {
        iconRect.position = Camera.main.WorldToScreenPoint(centerPos + Vector3.up * 3f);
    }
}
