using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;

    private List<GameObject> bullefFallFx = new List<GameObject>();
    private List<GameObject> bullefPrefabs = new List<GameObject>();
    private List<GameObject> rocketBullefPrefab = new List<GameObject>();
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }

    public void CreateBulletAndBulletFall(GameObject bullet, GameObject bulletFall, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBullet = Instantiate(bullet);
            GameObject tempBulletFall = Instantiate(bulletFall);
            
            bullefPrefabs.Add(tempBullet);
            bullefFallFx.Add(tempBulletFall);
            
            bullefPrefabs[i].SetActive(false);
            bullefFallFx[i].SetActive(false);
        }
    }//create 

    public void CreateRocket(GameObject rocket, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempRocketBullet = Instantiate(rocket);
            
            rocketBullefPrefab.Add(tempRocketBullet);
            
            rocketBullefPrefab[i].SetActive(false);
        }
    }//create

    public GameObject SpawnBulletFallFX(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < bullefFallFx.Count; i++)
        {
            if (!bullefFallFx[i].activeInHierarchy)
            {
                bullefFallFx[i].SetActive(true);
                bullefFallFx[i].transform.position = position;
                bullefFallFx[i].transform.rotation = rotation;

                return bullefFallFx[i];

            }
        }
        
        return null;
        
    }//Spawn

    public void SpawnBullet(Vector3 position, Vector3 direction, Quaternion rotation, NameWeapon weaponName)
    {
        if (weaponName != NameWeapon.ROCKET)
        {
            for (int i = 0; i < bullefPrefabs.Count; i++)
            {
                if (!bullefPrefabs[i].activeInHierarchy)
                {
                    bullefPrefabs[i].SetActive(true);
                    bullefPrefabs[i].transform.position = position;
                    bullefPrefabs[i].transform.rotation = rotation;
                    
                    bullefPrefabs[i].GetComponent<BulletController>().SetDirection(direction);
                    
                    SetBulletDamage(weaponName,bullefPrefabs[i]);
                    
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < rocketBullefPrefab.Count; i++)
            {
                if (!rocketBullefPrefab[i].activeInHierarchy)
                {
                    rocketBullefPrefab[i].SetActive(true);
                    rocketBullefPrefab[i].transform.position = position;
                    rocketBullefPrefab[i].transform.rotation = rotation;
                    
                    rocketBullefPrefab[i].GetComponent<BulletController>().SetDirection(direction);
                    
                    SetBulletDamage(weaponName,rocketBullefPrefab[i]);
                    
                    break;
                }
            }
        }
    }

    private void SetBulletDamage(NameWeapon weaponname, GameObject bullet)
    {
        switch (weaponname)
        {
            case NameWeapon.PISTOL:
                bullet.GetComponent<BulletController>().damage = 2;
                break;
            case NameWeapon.MP5:
                bullet.GetComponent<BulletController>().damage = 3;
                break;
            case NameWeapon.M3:
                bullet.GetComponent<BulletController>().damage = 4;
                break;
            case NameWeapon.AK:
                bullet.GetComponent<BulletController>().damage = 5;
                break;
            case NameWeapon.AWP:
                bullet.GetComponent<BulletController>().damage = 10;
                break;
            case NameWeapon.ROCKET:
                bullet.GetComponent<BulletController>().damage = 10;
                break;
            
        }
    }
}
