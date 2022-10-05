using System.Collections;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Array that holds sound type and respective audio clip.
    public SoundType[] sounds;

    public AudioSource soundEffect; // Audio source to play sound effects.

    // Implementation of singleton design pattern.
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // For sound effects.
    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
    }

    // Returns audio clip based on sound effect selected.
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType returnSound = Array.Find(sounds, item => item.soundType == sound);
        return returnSound.soundClip;
    }

    // Class to hold sound effect type and respective audio clip.
    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }

    // Enum to select sound effect.
    public enum Sounds
    {
        PlayerJump,
        Point,
        PlayerDie
    }
}
