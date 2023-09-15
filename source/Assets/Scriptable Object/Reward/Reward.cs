using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reward", menuName = "Scriptable Object/Reward")]
public class Reward : ScriptableObject
{
    public int rewardMoney;
    public int rewardStat;
    public ItemData rewardItem;
}
