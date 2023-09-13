using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public bool equip;
    public float weight;
    public bool stackable;
    public bool usable;
}
