using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weaponsUnLocked;
    public WeaponController[] totalWeapons;

    [HideInInspector] 
    public WeaponController currentWeapon;
    private int currentWeaponIndex;

    private TypeControlAttack currentTypeControll;

    private PlayerArmController[] armController;

    private PlayerAnimations playerAnim;

    private bool isShooting;

    public GameObject meleeDamagePoint;

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        
        LoadActiveWeapons();
        
        currentWeaponIndex = 1;
    }

    private void Start()
    {
        armController = GetComponentsInChildren<PlayerArmController>();
        
        ChangeWeapon(weaponsUnLocked[1]);
        
        playerAnim.SwitchWeaponAnimation((int)weaponsUnLocked[currentWeaponIndex].defaultConfing.typeWeapon);
    }

    private void LoadActiveWeapons()
    {
        weaponsUnLocked.Add(totalWeapons[0]);

        for (int i = 1; i <totalWeapons.Length; i++)
        {
            weaponsUnLocked.Add(totalWeapons[i]);
        }
    }

    public void SwitchWeapon()
    {
        currentWeaponIndex++;

        currentWeaponIndex = (currentWeaponIndex >= weaponsUnLocked.Count) ? 0 : currentWeaponIndex;
        
        playerAnim.SwitchWeaponAnimation((int)weaponsUnLocked[currentWeaponIndex].defaultConfing.typeWeapon);
        
        ChangeWeapon(weaponsUnLocked[currentWeaponIndex]);
    }

    private void ChangeWeapon(WeaponController newWeapon)
    {
        if (currentWeapon)
        {
            currentWeapon.gameObject.SetActive(false);

        }

        currentWeapon = newWeapon;
            currentTypeControll = newWeapon.defaultConfing.typeControl;
            
            newWeapon.gameObject.SetActive(true);

            if (newWeapon.defaultConfing.typeWeapon == TypeWeapon.TwoHand)
            {
                for (int i = 0; i < armController.Length; i++)
                {
                    armController[i].ChangeToTwoHand();
                }
            }
            else
            {
                for (int i = 0; i < armController.Length; i++)
                {
                    armController[i].ChangeToOnHand();
                }
            }
        }

    public void Attack()
    {
        if (currentTypeControll == TypeControlAttack.Click)
        {
            if (!isShooting)
            {
                currentWeapon.CallAttack();
                isShooting = true;
            }   
        }
        else
        {
            Debug.Log("тест для других оружеек!");
        }
    }

    public void ResetAttack()
    {
        isShooting = false;
    }

    private void AllowCollisionDetection()
    {
        meleeDamagePoint.SetActive(true);
    }

    private void DenyCollisionDetection()
    {
        meleeDamagePoint.SetActive(false);
    }
    }

