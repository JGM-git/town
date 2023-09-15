using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TalkManager talkManager;
    public NpcManager npcManager;
    public Quest quest;
    public int count;
    public Inventory invenTory;
    
    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
        talkManager = FindObjectOfType<TalkManager>();
        invenTory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (quest.questType == "GetItem")
        {
            count = invenTory.inven[quest.questItem];
        }
        else if (quest.questType == "NpcTalk")
        {
            if (talkManager.isTalking == true && quest.npcId == npcManager.npcId)
            {
                quest.condition = true;
            }
        }

        if (count >= quest.countEnd || quest.condition == true) quest.isComplete = true;
        else quest.isComplete = false;
    }

    public void AddQuest()
    {
        quest = npcManager.quest;
        count = 0;
        quest.onProgress = true;
    }
    
    public void CompleteQuest()
    {
        
    }
    

    public void AbandonQuest()
    {
        
    }
    

}
