using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public AudioClip resourceGather;
    public AudioSource audioS;

    public void playResourceSound()
    {
        audioS.PlayOneShot(resourceGather);
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
