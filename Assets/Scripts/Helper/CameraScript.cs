using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform playerTransform;
    
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYERTAG).transform;
    }

    private void LateUpdate()
    {
        if (playerTransform)
        {
            if (GamePlayController.instance.gameGoal != GameGoal.DEFENDFANCE &&
                GamePlayController.instance.gameGoal != GameGoal.GAMEOVER)
            {
                FollowPlayer();
            }
            
        }
    }

    private void FollowPlayer()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        transform.position = temp;
    }
}
