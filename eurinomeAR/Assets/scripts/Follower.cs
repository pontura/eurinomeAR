using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public float smooth = 10;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, smooth * Time.deltaTime);
    }
}
