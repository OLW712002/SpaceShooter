using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyScreenShake = false;
    [SerializeField] bool isPlayer;

    [Header("EnemySetting")]
    [SerializeField] int score = 100;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        levelManager = FindObjectOfType<LevelManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
            audioPlayer.PlayHittingClip();
            dmgDealer.Hit();
        }
    }

    void TakeDmg(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDmgAmount();
        if (health <= 0) Die();
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.AddScore(score);
        }
        else
        {
            levelManager.LoadResult();
        }
        Destroy(gameObject);
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
