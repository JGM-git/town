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
        questList.Add(questId = 10, new QuestData("�������", new int[0]));
        questList.Add(questId = 20, new QuestData("�ȳ���������", new int[0]));
        
    }

    public void GetQuestIndex()
    {
        if (npcManager.quest == true)
        {
            questId = npcManager.questId;
        }

    }

    public void AddQuest() //���� ����Ʈ ����Ʈ�� �߰�
    {
        //questList���� questId�� ��ȸ�� �Ŀ� playerQuestList�� �߰� 
        QuestData qd = questList[questId];
        playerQuestList.Add(questId, qd);
    }

    public bool CompleteQuest()
    {
        return playerQuestList.Remove(npcManager.questId);
        // ���� ����
    }

    public Dictionary<int, QuestData> CheckCurrentQuest()
    {
        return playerQuestList;
    }

    public void AbandonQuest()
    {
        //����Ʈ UI���� ���� ��ư Ŭ���� ����Ʈ ���� (playerQusetList���� ����)
    }


}
