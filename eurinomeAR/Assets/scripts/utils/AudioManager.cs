using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSourceManager[] all;
    [Serializable]
    public class AudioSourceManager
    {
        public string sourceName;
        [HideInInspector] public AudioSource audioSource;
        public float volume = 1;
    }
    void Start()
    {
        Events.PlaySpecificSound += PlaySpecificSound;
        Events.PlaySpecificSoundInArray += PlaySpecificSoundInArray;
        Events.PlaySound += PlaySound;
        Events.ChangeVolume += ChangeVolume;
        foreach (AudioSourceManager m in all)
        {
            m.audioSource = gameObject.AddComponent<AudioSource>();
            m.audioSource.volume = m.volume;
        }
    }
    private void OnDestroy()
    {
        Events.PlaySpecificSound -= PlaySpecificSound;
        Events.PlaySpecificSoundInArray -= PlaySpecificSoundInArray;
        Events.ChangeVolume -= ChangeVolume;
        Events.PlaySound -= PlaySound;
    }
    void ChangeVolume(string sourceName, float volume)
    {
        foreach (AudioSourceManager m in all)
        {
            if (m.sourceName == sourceName)
                m.audioSource.volume = volume;
        }
    }
    void PlaySpecificSoundInArray(AudioClip[] allClips)
    {
        PlaySpecificSound(allClips[UnityEngine.Random.Range(0, allClips.Length)]);
    }
    void PlaySpecificSound(AudioClip audioClip)
    {
        AudioSource audioSource = GetAudioSource("common"); if (audioSource == null)  return;
        if (audioClip == null)
            audioSource.Stop();
        else
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
    void PlaySound(string sourceName, string audioName, bool loop)
    {
        AudioSource audioSource = GetAudioSource(sourceName);
        if (audioSource == null) return;

        audioSource.clip = Resources.Load<AudioClip>("Audio/" + audioName) as AudioClip;
        audioSource.Play();
        audioSource.loop = loop;
    }
    AudioSource GetAudioSource(string sourceName)
    {
        foreach (AudioSourceManager m in all)
        {
            if (m.sourceName == sourceName)
                return m.audioSource;
        }
        return null;
    }
}
