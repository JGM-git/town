using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuestPanel : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private RectTransform rect;
    public bool questPanelOpened = false;
    [SerializeField]
    private Vector2 closedSize;
    [SerializeField]
    private Vector2 openedSize;
    public GameObject QuestInfoPanel;
    private UIManager uiManager;
    
    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        rect = GetComponent<RectTransform>();
    }

    public void ManagePanel(Quest quest)
    {
        questPanelOpened = !questPanelOpened;
        if (questPanelOpened)
        {
            uiManager.SetPanelDetail(quest);
            QuestInfoPanel.SetActive(true);
            rect.DOSizeDelta(openedSize, .3f);
        }
        else
        {
            rect.DOSizeDelta(closedSize, .3f);
            QuestInfoPanel.SetActive(false);
        }
    }
}
