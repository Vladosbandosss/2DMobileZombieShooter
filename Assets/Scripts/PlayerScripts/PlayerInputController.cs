using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputController : MonoBehaviour
{
    private WeaponManager _weaponManager;

    [HideInInspector] 
    public bool canShoot;

    private bool isHoldAttack;//не юзаю

    private void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
    }
    
    public void SwitchWeapon()
    {
        _weaponManager.SwitchWeapon();
    }

    private void Update()
    {
        Shooting();
    }

    public void PressAttackButton()
    {
        isHoldAttack = true;
    }

    public void ReleaseAttackButton()
    {
        _weaponManager.ResetAttack();
        isHoldAttack = false;
    }

    private void Shooting()
    {
        if (isHoldAttack && canShoot)
        {
            _weaponManager.Attack();
        }
    }
    
}
