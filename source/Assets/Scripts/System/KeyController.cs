using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private UIManager ui;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }
    
    void Update()
    {
        // S - INFO OPEN
        if(Input.GetKeyDown(KeyCode.S))
        {
            ui.ManageInfo();
        }
        // Q - QUEST OPEN
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ui.ManageQuest();
        }
        // E - INVEN OPEN
        if(Input.GetKeyDown(KeyCode.E))
        {
            ui.ManageInven();
        }
        
        // ESC
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // CLOSE WINDOW
            if(ui.windowStack.Count > 0)
            {
                ui.windowStack.Peek().Invoke();
                return;
            }
            // OPEN SETTING
            ui.ManageSetting();
        }
    }
}
