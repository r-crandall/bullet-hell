using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemy = true;
    public int numEnemies = 0;
    public Rigidbody enemyPrefab;
    public Transform spawner;
    public int maxEnemies = 10;


    private float timer = 1.0f;

    // Update is called once per frame
    void Update()
    {

        if (spawnEnemy)
        {
            numEnemies++;
            Rigidbody enemyInstance;
            enemyInstance = Instantiate(enemyPrefab, spawner.position, spawner.rotation);

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
