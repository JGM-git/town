using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public NpcManager npcManager;
    public Talk talk;

    // Start is called before the first frame update
    void Start()
    {
        npcManager = FindObjectOfType<NpcManager>();
    }

    public void GenerateData()
    {

    }

    public void GetTalk()
    {
        talk = npcManager.talk;
    }

    public void Talking()
    {
        Debug.Log(talk.line[0]);
    }
}
