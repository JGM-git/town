using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void Start()
    {
        DOTween.Init();
    }
    
    public void OnPointerEnter(PointerEventData e)
    {
        transform.DOScale(Vector3.one * 1.5f, 0.3f);
    }

    public void OnPointerExit(PointerEventData e)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
}
