using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimations : MonoBehaviour
{
   private Animator _anim;

   private void Awake()
   {
      _anim = GetComponent<Animator>();
   }

   public void Attack()
   {
      _anim.SetTrigger(TagManager.ATTACKPARAMETR);
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
