using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameWeapon
{
    MELEE,
    PISTOL,
    MP5,
    M3,
    AK,
    AWP,
    FIRE,
    ROCKET
}
public class WeaponController : MonoBehaviour
{
    public DefaultConfing defaultConfing;
    public NameWeapon nameWP;

    protected PlayerAnimations _playerAnim;
    protected float lastShoot;

    public int gunIndex;
    public int currentBullet;
    public int bulletMax;

    private void Awake()
    {
        _playerAnim = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMax;
    }

    public void CallAttack()
    {
        if (Time.time > lastShoot + defaultConfing.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();
                //an shoot
                _playerAnim.AttackAnimation();

                lastShoot = Time.time;
                currentBullet--;
            }
            else
            {
                //Play no ammo sound
            }
        }
    }

    public virtual void ProcessAttack()
    {
        
    }
}
