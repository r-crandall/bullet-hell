using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioClip fireGun;
    public AudioClip reload;
    public AudioSource audioS;

    public Rigidbody projectilePrefab;
    public Transform spawner;


    public float projectileForce = 500.0f;
    public float fireRate = 1.0f;
    public float reloadTime = 1.0f;
    public float fireGunCD = 0.2f;
    public int ammoPerClip = 10;
    public int totalAmmo = 100;
    public int mouseFireButton = 0;

    private float RLTimer; //reloadTimer
    private int currentAmmoInClip;
    private bool reloading = false;
    private float fireGunCDTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RLTimer = reloadTime;
        currentAmmoInClip = ammoPerClip;
        Debug.Log("Current Ammo In Clip: " + currentAmmoInClip);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmoInClip == 0)
        {
            reloading = true;
        }

        if (fireGunCDTimer >= 0f)
        {
            fireGunCDTimer -= Time.deltaTime;
        }

        if (reloading)
        {
            RLTimer -= Time.deltaTime;
        }

        if (RLTimer <= 0f)
        {
            Reload();
        }

        if (Input.GetMouseButton(mouseFireButton) && fireGunCDTimer < 0f && currentAmmoInClip > 0 && reloading == false)
        {
            fireGunCDTimer = fireGunCD;
            FireGunAudio();
            FireGun();
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmoInClip < ammoPerClip && totalAmmo > 0)
        {
            reloading = true;
        }
    }

    private void FireGun()
    {
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectilePrefab, spawner.position, spawner.rotation) as Rigidbody;
        projectileInstance.AddForce(spawner.forward * projectileForce);
        currentAmmoInClip--;
        totalAmmo--;
    }

    void Reload()
    {
        if (ammoPerClip >= totalAmmo)
        {
            currentAmmoInClip = totalAmmo;
        }
        else
        {
            currentAmmoInClip = ammoPerClip;
        }
        reloading = false;
        RLTimer = reloadTime;
    }

    public void FireGunAudio()
    {
        audioS.PlayOneShot(fireGun);
    }

    public void ReloadGunAudio()
    {
        audioS.PlayOneShot(reload);
    }
}
