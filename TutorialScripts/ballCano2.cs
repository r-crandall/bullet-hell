using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCano2 : MonoBehaviour
{

    public Rigidbody ball2Prefab;
    public Transform spawner;
    public float projectileForce = 10000.0f;
    private Rigidbody ballInstance;
    public float spawnBall1 = 1.0f;
    public float spawnBall2 = 1.0f;

    // Update is called once per frame

    void Start()
    {
        InvokeRepeating("spawnBall", spawnBall1, spawnBall2);
    }

    void Update()
    {

    }
    void spawnBall()
    {
        ballInstance = Instantiate(ball2Prefab, spawner.position, spawner.rotation) as Rigidbody;
        ballInstance.AddForce(spawner.forward * projectileForce);
    }
}
