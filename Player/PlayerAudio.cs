using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public AudioClip resourceGather;
    public AudioClip playerDamaged;
    public AudioSource audioS;

    public void playResourceSound()
    {
        audioS.PlayOneShot(resourceGather);
    }

    public void playSound(AudioClip sound)
    {
        audioS.PlayOneShot(sound);
    }
    /*
    public void playFireProjSound()
    {
        print(audioS); //prints.
        audioS.Play();

        //audioS.PlayOneShot(fireProjectile);
    }
    */
}
