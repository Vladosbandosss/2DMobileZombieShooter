using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieController : MonoBehaviour
{
   private ZombieMove _zombieMove;
   private ZombieAnimations _zombieAnimation;

   private Transform targetTransform;
   private bool canAttack;
   private bool zombieAlive = true;

   public GameObject damageCollider;
   public int zombieHealth = 10;
   public GameObject[] fxDead;

   private float timerAttack;

   private int fireDamage = 10;

   public GameObject coinCollect;

   private float followPos = 1.5f;

   private void Start()
   {
      _zombieMove = GetComponent<ZombieMove>();
      _zombieAnimation = GetComponent<ZombieAnimations>();

      if (GamePlayController.instance.zombieGoal == ZombieGoal.PLAYER)
      {
         targetTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYERTAG).transform;
      }else if (GamePlayController.instance.zombieGoal == ZombieGoal.FENCE)
      {
         GameObject[] fences = GameObject.FindGameObjectsWithTag(TagManager.FENCE);

         targetTransform = fences[Random.Range(0, fences.Length)].transform;
      }
   }

   private void Update()
   {
      if (zombieAlive)
      {
         CheckDistance();
      }
   }

   private void CheckDistance()
   {
      if (targetTransform)
      {
         if (Vector3.Distance(targetTransform.position, transform.position) > followPos)
         {
            _zombieMove.Move(targetTransform);
            
         }else
         {
            if (canAttack)
            {
               _zombieAnimation.Attack();
            }
         }
      }
      
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag(TagManager.PLAYERHEALTH) || 
          other.CompareTag(TagManager.PLAYERTAG)||
          other.CompareTag(TagManager.FENCE))
      {
         canAttack = true;
      }

      if (other.CompareTag(TagManager.BULLET) || other.CompareTag(TagManager.ROCHETMISSILE))
      {
         _zombieAnimation.Hurt();

         zombieHealth -= other.gameObject.GetComponent<BulletController>().damage;

         if (other.CompareTag(TagManager.ROCHETMISSILE))
         {
            other.gameObject.GetComponent<BulletController>().ExplosionFX();
         }

         if (zombieHealth <= 0)
         {
            zombieAlive = false;
            _zombieAnimation.Dead();

            StartCoroutine(nameof(DeactivateZombie));

         }
         
         other.gameObject.SetActive(false);
      }
      
      if (other.CompareTag(TagManager.FIREBULLET))
      {
         _zombieAnimation.Hurt();

         zombieHealth -= fireDamage;
         
         if (zombieHealth <= 0)
         {
            zombieAlive = false;
            _zombieAnimation.Dead();

            StartCoroutine(nameof(DeactivateZombie));

         }
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag(TagManager.PLAYERHEALTH) || 
          other.CompareTag(TagManager.PLAYERTAG)||
          other.CompareTag(TagManager.FENCE))
      {
         canAttack = false;
      }
   }

   public void ActivateDeadEffect(int index)
   {
      fxDead[index].SetActive(true);

      if (fxDead[index].GetComponent<ParticleSystem>())
      {
         fxDead[index].GetComponent<ParticleSystem>().Play();
      }
   }
   private IEnumerator DeactivateZombie()
   {
      yield return new WaitForSeconds(2f);
      
      //Instantiate(coinCollect, transform.position, Quaternion.identity);
     
      gameObject.SetActive(false);
   }

   public void DealDamage(int damage)
   {
      _zombieAnimation.Hurt();

      zombieHealth -= damage;

      if (zombieHealth <= 0)
      {
         zombieAlive = false;
         _zombieAnimation.Dead();

         StartCoroutine(nameof(DeactivateZombie));
      }
   }

   private void ActivateDamagePoint()
   {
      damageCollider.SetActive(true);
   }

   private void DeactivateDamagePoint()
   {
      damageCollider.SetActive(false);
   }
}
