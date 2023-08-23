using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintInteractable : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private Vector3 centerPos;
    private GameObject interactablePrefab;
    private GameObject instantiated;

    void Start()
    {
        interactablePrefab = Resources.Load<GameObject>("Icons/InteractableIcon");
    }

    public void GenerateIcon()
    {
        centerPos = GetComponent<MeshRenderer>().bounds.center;
        //instantiated = Instantiate(interactablePrefab, centerPos + Vector3.up * 2.5f, Quaternion.identity);
        instantiated = Instantiate(interactablePrefab);
        instantiated.transform.SetParent(transform);
    }

    public void DestroyIcon()
    {
        Destroy(instantiated);
    }
}
