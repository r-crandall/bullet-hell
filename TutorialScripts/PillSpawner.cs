using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillSpawner : MonoBehaviour
{

    private Rigidbody pillInstance;
    private int numPills = 0;

    public Rigidbody pillPrefab;
    public Transform spawner;

    public int maxPills = 10;
    public float projectileForce = 100.0f;
    public float timeBeforefirst = 1.0f;
    public float timeBetween = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numPills>= maxPills)
        {
            CancelInvoke();

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            InvokeRepeating("SpawnPills", timeBeforefirst, timeBetween);
        }
    }

    public void SpawnPills()
    {
        pillInstance = Instantiate(pillPrefab, spawner.position, spawner.rotation) as Rigidbody;
        pillInstance.AddForce(spawner.forward * projectileForce);
        numPills++;
        print("Spawned Pill # " + numPills);
    }
}
