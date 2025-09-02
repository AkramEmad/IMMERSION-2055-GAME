using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float spawnRadius = 10f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector3 spawnPos = player.position + new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            0,
            Random.Range(-spawnRadius, spawnRadius)
        );

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}