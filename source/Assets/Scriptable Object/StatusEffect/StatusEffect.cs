using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusEffect", menuName = "Scriptable Object/StatusEffect", order = int.MaxValue)]
public class StatusEffect : ScriptableObject
{
    public string name;
    public string tooltip;
    public Sprite icon;
}
