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
    public float firstValue;
    public float currentValue;

    private CinemachineVirtualCamera cam;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.m_Lens.OrthographicSize = firstValue;
    }
    
    
    public void Zoom(float scroll)
    {
        currentValue -= scroll * 1.2f;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        cam.m_Lens.OrthographicSize = currentValue;
    }

    public void Reset()
    {
        currentValue = firstValue;
        cam.m_Lens.OrthographicSize = currentValue;
    }
}
