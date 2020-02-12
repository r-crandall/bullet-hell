using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public float fireCD = 1.0f; //fireCD could be named better probably
    public float projectileForce = 1000.0f;
    public int maxAmmo = 10;
    public float reloadTimer = 3.0f;

    public Rigidbody projectilePrefab;
    public Transform spawner;

    private int currAmmo;
    private float timer;
    private bool reloading = false;

    private void Start()
    {
        timer = fireCD;
        currAmmo = maxAmmo;
    }

    void Update()
    {
        if (currAmmo == 0)
        {
            reloading = true;
        }

        if (reloading)
        {
            reloadTimer -= Time.deltaTime;
        }

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f && currAmmo > 0)
        {
            FireProjectile();
            currAmmo--;
        }

        if (reloadTimer <= 0f)
        {
            Reload();
        }
    }

    void FireProjectile()
    {
        timer = fireCD;
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectilePrefab, spawner.position, spawner.rotation) as Rigidbody;
        projectileInstance.AddForce(spawner.forward * projectileForce);
    }

    void Reload()
    {
        //enemyAudio.playReloadSound();
        Debug.Log("Enemy Reload() called");
        currAmmo = maxAmmo;
        reloading = false;
        reloadTimer = 3.0f;
    }
}
