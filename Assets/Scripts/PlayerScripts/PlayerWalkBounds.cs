using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBounds : MonoBehaviour
{
    private float minX = -10f, maxX = 150f;

    private void Update()
    {
        MovementBounds();
    }

    private void MovementBounds()
    {
        Vector3 temp = transform.position;

        if (temp.x < minX)
        {
            temp.x = minX;
        }

        if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        transform.position = temp;
    }
}
