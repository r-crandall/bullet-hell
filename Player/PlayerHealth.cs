using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float playerMaxHealth = 100.0f;
    public float playerCurrentHealth;

    public int expGained = 0;
    public bool levelUp = false;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void ReduceCurrentHealth(float amount)
    {
        //play "hurt" sound
        Debug.Log("ReduceHealth() Called");
        playerCurrentHealth -= amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            reduceCurrentHealth(projectile.projectileDmg);
            if (playerCurrentHealth <= 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        if (collision.gameObject.tag == "Resource")
        {
            Resource resource = collision.gameObject.GetComponent<Resource>();
            increaseCurrentHealth(resource.resourceHeal);
        }
    }

    public void reduceCurrentHealth(float amount)
    {
        playerCurrentHealth -= amount;
    }

    public void increaseCurrentHealth(float amount)
    {
        float newHealth = playerCurrentHealth + amount;
        if (newHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        else
        {
            playerCurrentHealth = newHealth;
        }
    }
}
