using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TalkManager talkManager;
    public NpcManager npcManager;
    public List<Quest> questList;
    public int count;
    public Inventory invenTory;
    
    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
        talkManager = FindObjectOfType<TalkManager>();
        invenTory = FindObjectOfType<Inventory>();

        questList = new List<Quest>();
    }

    void Update()
    {
        foreach (Quest quest in questList)
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
    }

    public void AddQuest()
    {        
        npcManager.quest.onProgress = true;
        questList.Add(npcManager.quest);
        count = 0;
    }
    
    public void CompleteQuest()
    {
        
    }
    

    public void AbandonQuest()
    {
        
    }
    

}
