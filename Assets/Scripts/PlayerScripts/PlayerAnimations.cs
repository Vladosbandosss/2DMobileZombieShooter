using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayerRunAnimation(bool run)
    {
        _anim.SetBool(TagManager.RUNPARAMETR,run);
    }

    public void AttackAnimation()
    {
        _anim.SetTrigger(TagManager.ATTACKPARAMETR);
    }

    public void SwitchWeaponAnimation(int typeWeapon)
    {
        _anim.SetInteger(TagManager.TYPEWEAPONPARAMETR,typeWeapon);
        _anim.SetTrigger(TagManager.SWITHPARAMETR);
    }

    public void Hurt()
    {
        _anim.SetTrigger(TagManager.GETHURTPARAMETR);
    }

    public void Dead()
    {
        _anim.SetTrigger(TagManager.DEADPARAMETR);
    }
}
