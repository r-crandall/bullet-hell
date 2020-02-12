using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCano : MonoBehaviour
{

    public Rigidbody ballPrefab;
    public Transform spawner;
    public float projectileForce = 10000.0f;
    private Rigidbody ballInstance;
    public float timeBeforefirst = 1.0f;
    public float timeBetween = 1.0f;
    public int maxBalls = 15;
    private int numBalls = 0; //Adding to specify the number of balls spawned.
    //private bool less---Do I need to add a bool here for the numballs<10?)

    // Update is called once per frame

    void Start()
    {
        //InvokeRepeating("spawnBall", spawnBall1, spawnBall2);    
    }

    void Update()
    {
        if (numBalls<maxBalls)
        {
            //spawnBalls();
            InvokeRepeating("SpawnBalls", timeBeforefirst, timeBetween);    
        }

        else
        {
            CancelInvoke();
        }
    }

    public void SpawnBalls() 
    {
        //for(int i = 0; i < maxBalls; i++) // for a ballCano type thing. 
        //{
            ballInstance = Instantiate(ballPrefab, spawner.position, spawner.rotation) as Rigidbody;
            ballInstance.AddForce(spawner.forward * projectileForce);
            numBalls++;
            print("Spawned Ball # " + numBalls);
        //}
    }
}

