using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimExtras : MonoBehaviour
{
    public AudioClip[] clipsID;

    public void PlayAudioClip(int id)
    {
        Events.PlaySpecificSound(clipsID[id]);
    }
}
