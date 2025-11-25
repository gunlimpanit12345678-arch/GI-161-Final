using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefabs;
    }

    public List<Wave> waves;
    public int currentWaveCount;

    float spawnerTimer;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public float waveInterval;

    public List<Transform> relativeSpawnerPoints;

    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    void Update()
    {
        Wave curWave = waves[currentWaveCount];

        // ถ้า spawn ครบ + มอนตายหมด → ไป Wave ต่อไป
        if (curWave.spawnCount >= curWave.waveQuota && enemiesAlive == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnerTimer += Time.deltaTime;

        if (spawnerTimer >= curWave.spawnInterval)
        {
            spawnerTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;

            // รีเซ็ต spawn counters
            waves[currentWaveCount].spawnCount = 0;
            foreach (var g in waves[currentWaveCount].enemyGroups)
                g.spawnCount = 0;

            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var group in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += group.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
    }

    void SpawnEnemies()
    {
        Wave curWave = waves[currentWaveCount];

        if (curWave.spawnCount >= curWave.waveQuota) return;

        foreach (var group in curWave.enemyGroups)
        {
            if (group.spawnCount >= group.enemyCount)
                continue;

            if (enemiesAlive >= maxEnemiesAllowed)
                return;

            Transform spawnOffset = relativeSpawnerPoints[Random.Range(0, relativeSpawnerPoints.Count)];

            Instantiate(group.enemyPrefabs, player.position + spawnOffset.position, Quaternion.identity);

            group.spawnCount++;
            curWave.spawnCount++;
            enemiesAlive++;

            break; // 🟢 สำคัญมาก! ให้ spawn ครั้งละ 1 ตัว
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}

