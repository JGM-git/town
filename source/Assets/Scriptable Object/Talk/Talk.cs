using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talk", menuName = "Scriptable Object/Talk")]
public class Talk : ScriptableObject
{
    public string[] line;
    public int talkIndex;
}
