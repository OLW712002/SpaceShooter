using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    [SerializeField] float delayForNextEnemy = 1.0f;

    void Start()
    {
        //SpawnEnemies();
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemiesCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
        }
        
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < currentWave.GetEnemiesCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSecondsRealtime(delayForNextEnemy);
        }
    }
}
