using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float lookRadius = 100.0f;

    Transform target;

    public float rotateStrength = 1.0f;

    private float timer;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        FaceTarget();
    }

    void FaceTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateStrength);        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
