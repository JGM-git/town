using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Object/QuestData")]
public class QuestData : ScriptableObject
{
    private string questName;
    private int[] npcId;
    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
