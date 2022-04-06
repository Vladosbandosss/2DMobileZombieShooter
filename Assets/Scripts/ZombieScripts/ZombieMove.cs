using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    private float moveSpeed = 1f;

    public void Move(Transform targetTransform)
    {
        Flip(targetTransform);
        
        transform.position=Vector3.MoveTowards(transform.position,
            new Vector3(targetTransform.position.x,
            targetTransform.position.y-0.9f,0f),moveSpeed*Time.deltaTime);
    }

    private void Flip(Transform targetTransform)
    {
        Vector3 temp = transform.position;
        Vector3 tempScale = transform.localScale;

        if (targetTransform.position.x > temp.x + 0.08f)
        {
            tempScale.x = -1f;
        }else if (targetTransform.position.x < temp.x - 0.08f)
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;
    }
}
