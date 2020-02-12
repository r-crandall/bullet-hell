using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    //type of resource (heal/ammo/etc)

    public float resourceHeal = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playResourceSound

            Destroy(gameObject);
        }
    }
    
}
