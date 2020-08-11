using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPak : MonoBehaviour
{
    //type of resource (heal/ammo/etc)

    public float healAmount = 10.0f;
    public AudioClip healSound;
    public AudioSource audioSource;
    private AudioManager audioManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playResourceSound();
            Player player = collision.gameObject.GetComponent<Player>();
            player.increaseCurrentHealth(healAmount);
            Destroy(gameObject);
        }
    }

    private void playResourceSound()
    {
        audioSource.PlayOneShot(healSound);
    }

}
