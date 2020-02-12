using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Renderer rend;
    Rigidbody enemyInstance;

    public float maxHealth = 10;
    public float currentHealth = 10;

    public bool dieOnPlayerCollision = true;

    public bool lerped; //lerped enemies could be stronger somehow.
    public Color damagedColor = Color.white; //lerped color 1
    private Color startColor;
    public float damagedTimer = 0.1f;
    private bool damaged;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void reduceCurrentHealth(float amount)
    {
        currentHealth -= amount;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //enemySpawnerScript.subtractEnemy();
            Destroy(gameObject);
            //death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            Damaged();
            reduceCurrentHealth(projectile.projectileDmg);
        }

        /*
        if (collision.gameObject.tag == "Player" && dieOnPlayerCollision)
        {
            currentHealth = 0;
        }
        */
    }

    void Damaged()
    {
        rend.material.color = damagedColor;
    }

}