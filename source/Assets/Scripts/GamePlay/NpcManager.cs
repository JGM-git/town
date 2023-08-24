using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private GameObject target;
    public int npcId;
    public int[] questId;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator NpcTalk()
    {
        transform.LookAt(target.transform);
        anim.SetBool("isTalking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isTalking", false);
    }

    public void NpcStop()
    {
        StartCoroutine (NpcTalk());
    }
}