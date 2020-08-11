using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Rigidbody player;

    public Transform target;
    private Vector3 cameraTarget;
    public Vector3 cameraOffset;

    //private float timer = 5.0f;
    public float camDistanceRatio = 0.5f;

    Vector3 offset;
    private Vector3 finalCamPosition;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 playerPos = player.position;
        Vector3 mousePos = Input.mousePosition;

        cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
        //   Vector3 targetCamPos = target.position + offset;


        Vector3 diff = playerPos - mousePos;
        finalCamPosition = playerPos + (diff * camDistanceRatio);
        transform.position = Vector3.Lerp(transform.position, finalCamPosition, Time.deltaTime * 100);
    }

}
