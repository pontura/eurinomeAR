using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotation : MonoBehaviour
{
    public Vector3 values;

    void Start()
    {
        
    }

    void Update()
    {
        if (values == Vector3.zero) return;
        Vector3 rot = Vector3.zero;
        if (values.x > 0) rot = Vector3.right * values.x;
        if (values.y > 0) rot = Vector3.up * values.y;
        if (values.z > 0) rot = Vector3.forward * values.z;
        transform.Rotate(rot);
    }
}
