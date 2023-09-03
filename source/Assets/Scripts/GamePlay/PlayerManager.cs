using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public float money;
    public Job currentJob;
    public int knowledge;
    public int luck;
    public int strength;
    public int driving;
    public int reputation;
    public int faith;
    public int life;
    public float stamina;
    public float maxStamina;
    public List<StatusEffect> statusEffects;

    public bool isDriving = false;

    private Animator anim;
    
    void Start()
    {
        stamina = maxStamina;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // STAMINA MANAGEMENT
        if (anim.GetFloat("Blend") == 1f)
        {
            if(stamina >= 0f)
                stamina -= Time.deltaTime * 15f;
        }
        else
        {
            if (stamina <= maxStamina)
                stamina += Time.deltaTime * 5f;
        }
    }
}
