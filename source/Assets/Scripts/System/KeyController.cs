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
    private CameraScroll cameraScroll;
    private Detector detector;
    private QuestManager questManager;
    private NpcManager npcManager;
    private PlayerManager playerManager;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        moveController = FindObjectOfType<MoveController>();
        cameraScroll = FindObjectOfType<CameraScroll>();
        detector = FindObjectOfType<Detector>();
        questManager = FindObjectOfType<QuestManager>();
        npcManager = FindObjectOfType<NpcManager>();
        playerManager = FindObjectOfType<PlayerManager>();
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
        // F - INTERACTION
        if(Input.GetKeyDown(KeyCode.F))
        {
            detector.DetectAction();
        }
        // U - EQUIPMENT OPEN
        if (Input.GetKeyDown(KeyCode.U))
        {
            if(ui.settingOpened) return;
            ui.ManageEquip();
        }
        // H - QUEST INTERACTION    
        if(Input.GetKeyDown(KeyCode.H))
        {
            questManager.GetQuestIndex();
            questManager.AddQuest();
            questManager.CheckCurrentQuest();
        }
        // T - DRIVING ANIMATION TEST
        if (Input.GetKeyDown(KeyCode.T))
        {
            moveController.DriveTest();
        }
        // ESC - MENU
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
        
        // SHIFT - RUN / CAR HEADLIGHT
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (playerManager.isDriving && playerManager.currentCar != null)
            {
                playerManager.currentCar.ManageLight();
                return;
            }
            
            moveController.Run();
        }
        
        // SCROLL - CAMERA ZOOM
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraScroll.Zoom(scroll);
        
        // WHEEL BUTTON - RESET CAMERA ZOOM
        if (Input.GetMouseButtonDown(2))
        {
            cameraScroll.Reset();
        }
    }
}
