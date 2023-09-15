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
    public bool isTalking;

    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
        uiManager = FindObjectOfType<UIManager>();
    }
    

    public void GetTalk()
    {
        if (npcManager.quest.onProgress == true)
        {
            talk = npcManager.questTalk;
            uiManager.ManageDialog();
            Talking();
        }
        else
        {
            talk = npcManager.talk;
            uiManager.ManageDialog();
            Talking();
        }
    }

    public void Talking()
    {
        isTalking = true;
        uiManager.PrintDialog(talk.line[talkIndex]);
        Debug.Log(talk.line[talkIndex]);
        talkIndex++;
        if (talkIndex == talk.talkIndex)
        {
            isTalking = false;
            uiManager.LastDialog();
            talkIndex = 0;
            // 퀘스트가 존재하는 Npc면 퀘스트 받을지 말지 고르기 받는 함수는 AddQuest함수 사용
            // 대화 UI창 끄기
            
        }
    }
}
