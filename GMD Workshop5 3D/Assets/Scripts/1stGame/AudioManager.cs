
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioSource ambientMusic;

    void Awake()
    {
        ambientMusic.volume = PlayerPrefs.GetFloat("Volume");

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Play(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == audioName);
        s.source.Play();
    }

}
