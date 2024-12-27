using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float timeBetweenProjectile = 1f;

    public bool isFiring = false;
    Coroutine firingCoroutine;

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring)
        {
            if (firingCoroutine == null) firingCoroutine = StartCoroutine(FireContinuously());
        }
        else
        {
            if (firingCoroutine != null)
            {
                StopCoroutine(firingCoroutine);
                firingCoroutine = null;
            }
            
        }
    }

    IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            yield return new WaitForSecondsRealtime(timeBetweenProjectile);
            Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity, transform);
        }
    }
}
