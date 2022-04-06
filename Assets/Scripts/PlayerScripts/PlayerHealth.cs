using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    public int health = 500;

    public GameObject[] bloodFX;

    private PlayerAnimations _playerAnimation;
    
    private void Awake()
    {
        _playerAnimation = GetComponentInParent<PlayerAnimations>();
    }

    public void DealDamage(int damage)
    {
        health -= damage;

        _playerAnimation.Hurt();

        if (health <= 0)
        {
            Debug.Log("игрок помер");
            GamePlayController.instance.playerAlive = false;
            
            GetComponent<Collider2D>().enabled = false;
            _playerAnimation.Dead();
            
            bloodFX[Random.Range(0,bloodFX.Length)].SetActive(true);
        }
    }
}
