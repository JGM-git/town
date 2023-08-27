using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int[] currentQuestId;
    public NpcManager npcManager;

    public Dictionary<int, QuestData> questList;
    public Dictionary<int, QuestData> playerQuestList;
    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
        questList = new Dictionary<int, QuestData>();
        GenerateQuestData();
    }

    public void GenerateQuestData()
    {
        questList.Add(questId = 10, new QuestData("어서오세요", new int[0]));
        questList.Add(questId = 20, new QuestData("안녕히가세요", new int[0]));
    }

    public void GetQuestIndex()
    {
        if (npcManager.quest == true)
        {
            questId = npcManager.questId;
        }

    }

    public void AddQuest() //현재 퀘스트 리스트에 추가
    {
        //questList에서 questId로 조회한 후에 playerQuestList에 추가 
        QuestData qd = questList[questId];
        playerQuestList.Add(questId, qd);
    }

    public bool CompleteQuest()
    {
        return playerQuestList.Remove(npcManager.questId);
        // 보상 지급
    }

    public Dictionary<int, QuestData> CheckCurrentQuest()
    {
        return playerQuestList;
    }

    public void AbandonQuest()
    {
        //퀘스트 UI에서 삭제 버튼 클릭시 퀘스트 포기 (playerQusetList에서 삭제)
    }


}
