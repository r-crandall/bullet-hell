using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    //type of resource (heal/ammo/etc)

    public float resourceHeal = 10.0f;
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playResourceSound
            Player player = collision.gameObject.GetComponent<Player>();
            player.increaseCurrentHealth(resourceHeal);
            Destroy(gameObject);
        }
    }
    
}
