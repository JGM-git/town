using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int[] currentQuestId;
    public NpcManager npcManager;
    public Quest quest;
    
    public List<int> playerQuestList;
    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
        playerQuestList = new List<int>();
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

    public List<int> CheckCurrentQuest()
    {
        return playerQuestList;
    }

    public void AbandonQuest()
    {
        
    }


}
