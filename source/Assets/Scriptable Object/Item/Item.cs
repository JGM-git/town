using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public bool equip;
    public int quantity;
    public bool stackable;
}
