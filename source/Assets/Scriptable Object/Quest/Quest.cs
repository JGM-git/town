using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Object/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public int npcId;
    public string reward;
}
