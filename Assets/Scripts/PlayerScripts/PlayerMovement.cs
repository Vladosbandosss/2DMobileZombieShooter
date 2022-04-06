using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    private float joystickYSensivity = 0.5f;
    private float joystickXSensivity = 0.25f;

    private PlayerAnimations _playerAnimations;

    private Rigidbody2D _rb;

    [SerializeField] private float MoveForceX = 1.5f, MoveForceY = 1.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float h = _joystick.Horizontal;
        float v = _joystick.Vertical;

        if (h>joystickXSensivity)
        {
            _rb.velocity = new Vector2(MoveForceX, _rb.velocity.y);
        }else if (h < -joystickXSensivity)
        {
            _rb.velocity = new Vector2(-MoveForceX, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
        }

        if (v > joystickYSensivity)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, MoveForceY);
        }else  if (v < -joystickYSensivity)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -MoveForceY);
        }
        else
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        }
        
        //Animate
        if (_rb.velocity.x != 0 || _rb.velocity.y != 0)
        {
            _playerAnimations.PlayerRunAnimation(true);
        }
        else if(_rb.velocity.x==0||_rb.velocity.y==0)
        {
            _playerAnimations.PlayerRunAnimation(false);
        }
        
        //ChangeRot
        Vector3 tempScale = transform.localScale;
        if (h > 0)
        {
            tempScale.x = -1f;
        }else if (h < 0)
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;
    }
}
