using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Renderer rend;
    Rigidbody projectileInstance;

    public Vector3 center;

    public Enemy enemy;

    private Explosion explosionScript;
    public int projectileDmg = 10;
    public float timeBeforeDestroy = 5.0f;
    public string destroyOnThisTag = "Enemy";

    public bool lerped;
    public Color LC1 = Color.white; //lerped color 1
    public Color LC2 = Color.black; //lerped color 2
    public Color lerpedColor = Color.white;

    public bool explodes = false;

    new private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        collider = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDestroy -= Time.deltaTime;
        if (timeBeforeDestroy < 0)
        {
            convertColliderToTrigger();
        }
        if (timeBeforeDestroy < -2)
        {
            Destroy(gameObject);
        }
        if (lerped)
        {
            lerpedColor = Color.Lerp(LC1, LC2, Mathf.PingPong(Time.time, 1));
            rend.material.color = lerpedColor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == destroyOnThisTag)
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            //convertColliderToTrigger();
            Destroy(gameObject);
        }

    }

    private void convertColliderToTrigger()
    {
        this.collider.isTrigger = true;
    }

}