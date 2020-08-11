using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawner;
    public int numEnemies = 0;
    public int maxEnemies = 10;
    public bool spawnEnemy = true;
    public float enemySpawnCD = 1.0f;
    private float enemySpawnTimer;


    private void Start()
    {
        enemySpawnTimer = enemySpawnCD;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTimer -= Time.deltaTime;

        if (spawnEnemy && enemySpawnTimer <= 0.0f)
        {
            numEnemies++;
            Transform enemyInstance;
            enemyInstance = Instantiate(enemyPrefab, spawner.position, spawner.rotation);
            enemySpawnTimer = enemySpawnCD;
        }

        if (numEnemies >= maxEnemies)
        {
            spawnEnemy = false;
        }
    }

    public void subtractEnemy()
    {
        numEnemies--;
    }

}
