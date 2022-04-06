using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{
    public Sprite oneHandSprite, twoHandSprite;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeToOnHand()
    {
        sr.sprite = oneHandSprite;
    }

    public void ChangeToTwoHand()
    {
        sr.sprite = twoHandSprite;
    }
}
