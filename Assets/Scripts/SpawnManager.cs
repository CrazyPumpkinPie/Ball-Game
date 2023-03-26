using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerups;
    public float spawnRange = 9;
    public float delayTime = 3, repeatTime = 2.5f;
    public int waveNumber = 1,enemyCount;
    void Start()
    {
        SpawnEnemyWave(1);
        //InvokeRepeating("SpawnEnemy", delayTime, repeatTime);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (enemiesToSpawn > 10) enemiesToSpawn = 10;
        int randomEnemy = Random.Range(0, enemies.Length);
        int randomPowerUp = Random.Range(0, powerups.Length);
        Instantiate(powerups[randomPowerUp], GenerateSpawnPosition(), powerups[randomPowerUp].transform.rotation);
        for (int i = 0; i < enemiesToSpawn; i++)
            Instantiate(enemies[randomEnemy], GenerateSpawnPosition(), enemies[randomEnemy].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawnPos;
    }
}
