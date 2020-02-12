using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName ="Resource")]
public class Resource1 : ScriptableObject
{
    public string resourceName;
    public string description;
    public Rigidbody resourcePrefab;

}
