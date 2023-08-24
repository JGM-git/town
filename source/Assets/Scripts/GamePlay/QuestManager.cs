using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public NpcManager npcManager;

    Dictionary<int, QuestData> questList;
    // Start is called before the first frame update
    void Start()
    {
        npcManager = GetComponent<NpcManager>();
        questList = new Dictionary<int, QuestData>();
        GenerateQuestData();
    }

    public void GenerateQuestData()
    {
        questList.Add(questId = 10, new QuestData("어서오세요", new int[0]));
    }

    public int GetQuestIndex(int id)
    {
        if (npcManager.npcId == id)
        {
            return questId =  npcManager.questId[0];
        }
        else return 0;
    }
  
}
