using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector] 
    public int damage;

    private float speed = 60f;

    private WaitForSeconds _waitForTimeAlive = new WaitForSeconds(2f);
    private IEnumerator coroutineDeactivate;

    private Vector3 direction;

    public GameObject rocketEXplos;

    private void Start()
    {
        if (this.tag == TagManager.ROCHETMISSILE)
        {
            speed = 8f;
        }
    }

    private void Update()
    {
        transform.Translate(direction*speed*Time.deltaTime);
    }

    private void OnEnable()
    {
        coroutineDeactivate = WaitForDeactivation();
        StartCoroutine(coroutineDeactivate);
    }

    private void OnDisable()
    {
        if (coroutineDeactivate != null)
        {
            StopCoroutine(coroutineDeactivate);
        }
    }

    private IEnumerator WaitForDeactivation()
    {
        yield return _waitForTimeAlive;
        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void ExplosionFX()
    {
        Instantiate(rocketEXplos, transform.position, Quaternion.identity);
    }
}
