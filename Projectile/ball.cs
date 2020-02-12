using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float timeUntilDestroy = 180.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeUntilDestroy);
        //numBalls--;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
