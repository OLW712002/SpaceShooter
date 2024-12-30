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
    [SerializeField] float firingTimeVariance = 0f;
    [SerializeField] float minimumFiringTime = 0.5f;
    [SerializeField] bool isAI;

    public bool isFiring = false;
    Coroutine firingCoroutine;
    GameObject projectileContainer;

    private void Awake()
    {
        projectileContainer = GameObject.Find("ProjectileContainer");
        if (projectileContainer == null) projectileContainer = new GameObject("ProjectileContainer");
    }

    void Start()
    {
        if (isAI)
        {
            isFiring = true;
        }
        else
        {

        }
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
            GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity, projectileContainer.transform);
            Destroy(projectile, projectileLifeTime);
            StartCoroutine(ProjectileMove(projectile));
            yield return new WaitForSecondsRealtime(
                Mathf.Clamp(UnityEngine.Random.Range(timeBetweenProjectile - firingTimeVariance, timeBetweenProjectile + firingTimeVariance),
                minimumFiringTime, float.MaxValue)
                );
        }
    }

    IEnumerator ProjectileMove(GameObject projectile)
    {
        float elapsedTime = 0f;
        while (elapsedTime < projectileLifeTime)
        {
            if (projectile != null)
            {
                projectile.transform.position += Vector3.up * projectileSpeed * Time.deltaTime;
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
    }
}
