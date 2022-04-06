using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;

    public int damage = 1;

    private bool playerDead;
    
    private void Update()
    {
        if (GamePlayController.instance.zombieGoal == ZombieGoal.PLAYER)
        {
            AttackPlayer();
        }

        if (GamePlayController.instance.zombieGoal == ZombieGoal.FENCE)
        {
            AttackFence();
        }
        
    }

    private void AttackPlayer()
    {
        if (GamePlayController.instance.playerAlive)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.tag==TagManager.PLAYERHEALTH)
            {
                Debug.Log(target.GetComponent<PlayerHealth>().health);
            
                target.GetComponent<PlayerHealth>().DealDamage(damage);
           
            }
        }
    }

    private void AttackFence()
    {
        if (!GamePlayController.instance.fenceDestroyed)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.tag == TagManager.FENCE)
            {
                target.GetComponent<FenceHealth>().DealDamage(damage);
            }
        }
    }
    
}
