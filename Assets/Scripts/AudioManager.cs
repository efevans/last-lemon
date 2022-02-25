using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioManager : IInitializable
{
    private AudioSource AudioSource { get; }
    private readonly Settings _settings;

    public AudioManager(Settings settings, AudioSource audioSource)
    {
        _settings = settings;
        AudioSource = audioSource;
    }

    public void Initialize()
    {
        AudioSource.clip = _settings.BGM;
        AudioSource.loop = true;
        AudioSource.volume = _settings.Volume;
        AudioSource.Play();
    }

    public void PauseBGM()
    {
        AudioSource.Pause();
    }

    public void UnpauseBGM()
    {
        AudioSource.UnPause();
    }

    [Serializable]
    public class Settings
    {
        public AudioClip BGM;
        [Range(0, 1)]
        public float Volume;
    }
}
