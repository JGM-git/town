using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    
    public NpcManager npcManager;
    public Talk talk;
    public int talkIndex = 0;
    private UIManager uiManager;

    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void GenerateData()
    {

    }

    public void GetTalk()
    {
        talk = npcManager.talk;
        uiManager.ManageDialog();
        Talking();
    }

    public void Talking()
    {
        uiManager.PrintDialog(talk.line[talkIndex]);
        Debug.Log(talk.line[talkIndex]);
        talkIndex++;
        if (talkIndex == talk.talkIndex) talkIndex = 0;
    }
}
