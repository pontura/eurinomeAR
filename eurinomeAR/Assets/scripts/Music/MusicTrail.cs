using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrail : MonoBehaviour
{
    public float speed = 10;
    Vector3 pos;
    public TrailRenderer trailRenderer;

    public void Goto(Vector3 pos, bool forced = false)
    {
        this.pos = pos;
        SetOn(forced);

        if (forced)
            transform.localPosition = pos;
        
    }
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, speed * Time.deltaTime);
    }
    bool isOn;
    void SetOn(bool _isOn)
    {
        if (_isOn == isOn)
            return;
        isOn = _isOn;
        if(isOn)
            trailRenderer.time = 0;
        else
            trailRenderer.time = 1;
    }
}
