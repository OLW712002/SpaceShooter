using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyScreenShake = false;

    CameraShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer dmgDealer = collision.GetComponent<DamageDealer>();
        if (dmgDealer != null)
        {
            TakeDmg(dmgDealer);
            PlayHitEffect();
            PlayScreenShake();
            dmgDealer.Hit();
        }
    }

    void TakeDmg(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDmgAmount();
        if (health <= 0) Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void PlayScreenShake()
    {
        if (cameraShake != null && applyScreenShake)
        {
            cameraShake.Play();
        }
    }
}
