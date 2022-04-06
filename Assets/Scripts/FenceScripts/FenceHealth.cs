using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceHealth : MonoBehaviour
{
    public int health = 500;
    public ParticleSystem woodBreakFx, woodExpFx;

    public void DealDamage(int damage)
    {
        health -= damage;
        woodBreakFx.Play();
        
        if (health <= 0)
        {
            woodExpFx.Play();
            
            GamePlayController.instance.fenceDestroyed = true;
          
            StartCoroutine(nameof(DeactivateFence));
            
        }
    }

    private IEnumerator DeactivateFence()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
