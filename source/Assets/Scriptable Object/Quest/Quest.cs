using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Object/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public string description;
    public int npcId;
    public Reward reward;
    public string questType;
    public int countEnd;
    public ItemData questItem;
    public bool isComplete;
    public bool condition;
    public bool onProgress;
}
