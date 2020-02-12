using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Applies an explosion force to all nearby rigidbodies
public class Explosion : MonoBehaviour
{
    public Vector3 center;
    public float explosionRadius = 5.0F;
    public float explosionPower = 10.0F;
    private Rigidbody projectileInstance;
    //public Vector3 explosionPos;
    private Enemy enemyScript;

    public void Explode()
    {
        Vector3 center = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(center, explosionRadius);
        foreach (Collider hit in colliders)
        {
            for(int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "Enemy")
                {
                    
                }

            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionPower, center, explosionRadius, 3.0F);
        }
    }

    private void ApplyExplosionDamage()
    {
           // enemyScript = collision.gameObject.GetComponent<Enemy>();
           // enemyScript.enemyHealth = enemyScript.enemyHealth - projectileDmg;
    }

}
