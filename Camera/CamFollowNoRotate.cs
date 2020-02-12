using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowNoRotate : MonoBehaviour
{
    public Transform target;
    private Vector3 cameraTarget;
    public Vector3 cameraOffset;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 100);
     //   Vector3 targetCamPos = target.position + offset;
    }

}
