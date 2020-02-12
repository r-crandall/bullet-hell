using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerMaxHealth = 100.0f;
    public float playerCurrentHealth; 

    public int expGained = 0;
    public bool levelUp = false;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Evolve();
        }

        if (levelUp)
        {
            Evolve();
            levelUp = false;
        }
    }

    void Evolve()
    {
        transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
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
        }

        if(collision.gameObject.tag == "ResourceHeal")
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
        playerCurrentHealth += amount;
    }
}