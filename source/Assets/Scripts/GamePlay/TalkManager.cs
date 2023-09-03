using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    // Start is called before the first frame update
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add(1000, new string[] { "���� x��"} );
    }

    public string GetTalk(int id, int talkingIndex)
    {
        return talkData[id][talkingIndex];
    }
}
