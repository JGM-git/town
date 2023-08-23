using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStop : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private GameObject target;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AnimTranslate());
    }

    IEnumerator AnimTranslate()
    {
        yield return new WaitForSeconds(0.5f);
        int idle = anim.GetInteger("Idle");
        idle = idle == 1 ? 2 : 1;
        anim.SetInteger("Idle", idle);
    }

    IEnumerator NpcTalk()
    {
        transform.LookAt(target.transform);
        anim.SetBool("isTalking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isTalking", false);
    }

    public void ManageNpcStop()
    {
        StartCoroutine (NpcTalk());
    }
}