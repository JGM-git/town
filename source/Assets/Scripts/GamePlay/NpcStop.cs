using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStop : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
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
}