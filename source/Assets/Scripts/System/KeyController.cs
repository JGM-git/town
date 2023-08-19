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
    private MoveController moveController;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        moveController = FindObjectOfType<MoveController>();
    }
    
    void Update()
    {
        // S - INFO OPEN
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(ui.settingOpened) return;
            ui.ManageInfo();
        }
        // Q - QUEST OPEN
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(ui.settingOpened) return;
            ui.ManageQuest();
        }
        // E - INVEN OPEN
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(ui.settingOpened) return;
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
            if(ui.quitOpened) return;  
            ui.ManageSetting();
        }
        
        //SHIFT
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveController.Run();
        }
        
    }
}
