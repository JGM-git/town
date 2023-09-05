using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int[] currentQuestId;
    public NpcManager npcManager;
<<<<<<< HEAD
    public Quest quest;
    
    public List<int> playerQuestList;
=======
    public Dictionary<int, QuestData> questList;
    public Dictionary<int, QuestData> playerQuestList;
>>>>>>> 4413c4b19ee41d809bc9445ff1685ab5077eddbe
    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
<<<<<<< HEAD
        playerQuestList = new List<int>();
=======
        questList = new Dictionary<int, QuestData>();
        GenerateQuestData();
    }

    public void GenerateQuestData()
    {
        questList.Add(questId = 10, new QuestData("�������", new int[0]));
        questList.Add(questId = 20, new QuestData("�ȳ���������", new int[0]));
        
>>>>>>> 4413c4b19ee41d809bc9445ff1685ab5077eddbe
    }
    

    public void GetQuestIndex()
    {
        if (npcManager.quest == true)
        {
            questId = npcManager.questId;
        }

    }

<<<<<<< HEAD
    public void AddQuest()
    {
        quest = npcManager.quest;
=======
    public void AddQuest() //���� ����Ʈ ����Ʈ�� �߰�
    {
        //questList���� questId�� ��ȸ�� �Ŀ� playerQuestList�� �߰� 
        QuestData qd = questList[questId];
        playerQuestList.Add(questId, qd);
>>>>>>> 4413c4b19ee41d809bc9445ff1685ab5077eddbe
    }

    public void CompleteQuest()
    {
<<<<<<< HEAD
        
=======
        return playerQuestList.Remove(npcManager.questId);
        // ���� ����
>>>>>>> 4413c4b19ee41d809bc9445ff1685ab5077eddbe
    }

    public List<int> CheckCurrentQuest()
    {
        return playerQuestList;
    }

    public void AbandonQuest()
    {
<<<<<<< HEAD
        
=======
        //����Ʈ UI���� ���� ��ư Ŭ���� ����Ʈ ���� (playerQusetList���� ����)
>>>>>>> 4413c4b19ee41d809bc9445ff1685ab5077eddbe
    }


}
