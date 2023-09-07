using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int[] currentQuestId;
    public NpcManager npcManager;
    public Quest quest;
    
    public Dictionary<int, Quest> questList;
    public Dictionary<int, Quest> playerQuestList;
    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
    }

    public void GenerateQuestData()
    {
        
    }
    

    public void GetQuestIndex()
    {
        if (npcManager.quest == true)
        {
            questId = npcManager.questId;
        }

    }

    public void AddQuest()
    {
        quest = npcManager.quest;
    }
    

    public void CompleteQuest()
    {
        
    }
    

    public void AbandonQuest()
    {
        
    }


}
