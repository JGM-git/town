using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    bool isTalking = false;
    public int talkingIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        talkManager = GetComponent<TalkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Talk(int id)
    {
        // ���� ��ȭ ��������
        string talkData = talkManager.GetTalk(id, talkingIndex);
        isTalking = true;
        if (talkData == null)
        {
            isTalking = false;
            talkingIndex = 0;
        }
        
        // �ؽ�Ʈ.text = talkData;
        talkingIndex++;
    }
}
