using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrail : MonoBehaviour
{
    public float speed = 10;
    Vector3 pos;
    public void Goto(Vector3 pos, bool forced = false)
    {
        this.pos = pos;
        if (forced)
            transform.localPosition = pos;
    }
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, speed * Time.deltaTime);
    }
}
