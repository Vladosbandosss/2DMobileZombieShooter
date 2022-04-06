using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeControlAttack
{
    Click
    //Hold
}

public enum TypeWeapon
{
    Melee,
    OneHand,
    TwoHand
}

[Serializable]
public struct DefaultConfing
{
    public TypeControlAttack typeControl;
    public TypeWeapon typeWeapon;
    
    [Range(0,100)]
    public int damage;
    
    [Range(0,100)]
    public int criticalDamage;
    
    [Range(0.01f,1.0f)]
    public float fireRate;
    
    [Range(0,100)]
    public int criticalRate;
}



