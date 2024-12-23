using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 10f;
    [SerializeField] bool isLooping = true;

    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(ReleaseWave());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator ReleaseWave()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                StartCoroutine(SpawnEnemiesWithDelay());
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        } while (isLooping);
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < currentWave.GetEnemiesCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
        }
    }
}
