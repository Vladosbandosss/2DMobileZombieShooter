using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    public Transform spawnPoint;
    public GameObject bullatPrefab;
    public ParticleSystem fxShoot;
    public GameObject fxBulletFall;

    private Collider2D fireCollider;

    private WaitForSeconds _waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);

    private int countBulletToPool = 100;

    private void Start()
    {
        if (!GamePlayController.instance.bulletAndBulFXCreated)
        {
            GamePlayController.instance.bulletAndBulFXCreated = true;
            
            if (nameWP !=NameWeapon.FIRE && nameWP != NameWeapon.ROCKET)
            {
                SmartPool.instance.CreateBulletAndBulletFall(bullatPrefab,fxBulletFall,countBulletToPool);
            }
        }

        if (!GamePlayController.instance.rocketBulCreated)
        {
            if (nameWP == NameWeapon.ROCKET)
            {
                GamePlayController.instance.rocketBulCreated = true;
                
                SmartPool.instance.CreateRocket(bullatPrefab,countBulletToPool);
            }
        }

        if (nameWP == NameWeapon.FIRE)
        {
            fireCollider = spawnPoint.GetComponent<BoxCollider2D>();
        }
    }

    public override void ProcessAttack()
    {
       // base.ProcessAttack();

       switch (nameWP)
       {
           case NameWeapon.PISTOL:
               break;
           case NameWeapon.MP5:
               break;
           case NameWeapon.M3:
               break;
           case NameWeapon.AK:
               break;
           case NameWeapon.AWP:
               break;
           case NameWeapon.FIRE:
               break;
           case NameWeapon.ROCKET:
               break;
       }

       if ((transform != null) &&(nameWP != NameWeapon.FIRE))
       {
           if (nameWP != NameWeapon.ROCKET)
           {
               GameObject bulletFalFX =
                   SmartPool.instance.SpawnBulletFallFX(spawnPoint.transform.position, Quaternion.identity);

               bulletFalFX.transform.localScale = transform.root.eulerAngles.y > 1.0f
                   ? new Vector3(-1f, 1f, 1f)
                   : new Vector3(1f, 1f, 1f);

               StartCoroutine(nameof(WaitForShootEffect));
           }
           
           SmartPool.instance.SpawnBullet
               (spawnPoint.transform.position,new Vector3(-transform.root.localScale.x,0f,0f)
                   ,spawnPoint.rotation,nameWP);
       }
       else
       {
           StartCoroutine(nameof(ActiveFireCollider));
       }
       
    }//

    private IEnumerator WaitForShootEffect()
    {
        yield return _waitTime;
        fxShoot.Play();
    }

    private IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;
        
        fxShoot.Play();
        
        yield return fireColliderWait;
        
        fireCollider.enabled = false;
    }
}
