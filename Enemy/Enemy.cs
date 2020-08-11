using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Renderer rend;
    Rigidbody enemyInstance;

    public float maxHealth = 100;
    private float currentHealth;

    public int enemyScore = 1;

    public bool lerped; //lerped enemies could be stronger somehow.
    public Color damagedColor = Color.white; //lerped color 1
    private Color startColor;
    public float damagedTimer = 0.1f;
    private bool damaged;

    void Start()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void reduceCurrentHealth(float amount)
    {
        Debug.Log("reduceCurrentHealth called, amount: " + amount.ToString());
        Debug.Log("CurrentHealth: " + currentHealth.ToString());
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
       //AudioSource.play damaged sound
        rend.material.color = damagedColor;
    }

}