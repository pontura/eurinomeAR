using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSourceTarget : MonoBehaviour
{
    AudioSource audioSource;
    float pitchValue = 1;
    float volumeValue = 1;
    public float pitchFactor = 0.2f;
    public float volumeFactor = 1.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ChangeValue(float value)
    {
        pitchValue = 1 + ((value - 0.5f) * pitchFactor);
    }
    public void SetValues(Vector2 coord)
    {
        float v = coord.x / Screen.width;
        ChangeValue(v);

        float vv = coord.y / Screen.height;
        audioSource.pitch = pitchValue;
    }
}
