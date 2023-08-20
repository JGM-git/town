using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScroll : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public float minValue;
    public float maxValue;
    public float currentValue;

    private CinemachineVirtualCamera cam;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    
    
    public void Zoom(float scroll)
    {
        currentValue -= scroll;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        cam.m_Lens.OrthographicSize = currentValue;
    }
}
