using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public float foodHealth = 100.0f;
    public float foodMovespeed = 1.0f;
    public float foodDamage = 1.0f;
    public float foodAmount = 10.0f;
    public int numResources = 4;

    public Rigidbody foodPrefab;

    public Rigidbody resourcePrefab;
    public Transform spawner;

    public Transform resourceSpawner1;
    public Transform resourceSpawner2;
    public Transform resourceSpawner3;
    public Transform resourceSpawner4;
    public Transform resourceSpawner5;
    public Transform resourceSpawner6;
    public Transform resourceSpawner7;
    public Transform resourceSpawner8;

    public float foodForce = 10.0f;

    Rigidbody foodInstance;
    Rigidbody resourceInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foodHealth <= 0)
        {
            Destroy(gameObject);
            SpawnResources(); // could be death();
        }
    }

    public void SpawnFood()
    {
        foodInstance = Instantiate(foodPrefab, spawner.position, spawner.rotation) as Rigidbody;
        foodInstance.AddForce(spawner.forward * foodForce);
    }

    public void SpawnResources()
    {
        void spawnResource1()
        {
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner1.position, resourceSpawner1.rotation);
        }

        void spawnResource2()
        {
            spawnResource1();
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner2.position, resourceSpawner2.rotation);
        }
        void spawnResource3()
        {
            spawnResource2();
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner3.position, resourceSpawner3.rotation);
        }
        void spawnResource4()
        {
            spawnResource3();
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner4.position, resourceSpawner4.rotation);
        }
        void spawnResource8()
        {
            spawnResource4();
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner5.position, resourceSpawner5.rotation);
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner6.position, resourceSpawner6.rotation);
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner7.position, resourceSpawner7.rotation);
            resourceInstance = Instantiate(resourcePrefab, resourceSpawner8.position, resourceSpawner8.rotation);
        };

        if (numResources == 1)
        {
            spawnResource1();
        }
        else if (numResources == 2)
        {
            spawnResource2();
        }
        else if (numResources == 3)
        {
            spawnResource3();
        }
        else if (numResources ==4)
        {
            spawnResource4();
        }
        else
        {
            spawnResource8();
        }
        
    }

    private void DestroyFood()
    {
        if (foodHealth >= 0)
        {
            Destroy(gameObject);
        }
    }

}
