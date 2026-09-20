using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioClip[] sfx;
    public AudioClip[] background;

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (AudioClip ac in sfx)
        {
            GameObject soundClip = new GameObject("SFX_" + ac.name);
            soundClip.transform.SetParent(transform);

            AudioSource source = soundClip.AddComponent<AudioSource>();
            source.clip = ac;
            source.volume = 0.5f;
            source.loop = false;
            if (ac.name == "GhostMove")
            {
                source.loop = true;
            }
        }

        foreach (AudioClip ac in background)
        {
            GameObject soundClip = new GameObject("BGM_" + ac.name);
            soundClip.transform.SetParent(transform);

            AudioSource source = soundClip.AddComponent<AudioSource>();
            source.clip = ac;
            source.volume = 0.5f;
            source.loop = true;
            if (ac.name == "Entry")
            {
                source.loop = false;
            }
        }
    }

    public void Play(string clipName)
    {
        AudioClip clip1 = Array.Find(sfx, item => item.name == clipName);
        AudioClip clip2 = Array.Find(background, item => item.name == clipName);

        if (clip1 == null && clip2 == null)
        {
            Debug.Log("Sound {clipName} not found!");
            return;
        }

        Transform child = transform.Find("SFX_" + clipName);
        if (child == null)
        {
            child = transform.Find("BGM_" + clipName);
        }
        if (child != null && child.TryGetComponent<AudioSource>(out var source))
        {
            source.Play();
        }

    }

    public void Stop(string clipName)
    {
        Transform child = transform.Find("SFX_" + clipName);
        if (child == null)
        {
            child = transform.Find("BGM_" + clipName);
        }

        if (child != null && child.TryGetComponent<AudioSource>(out var source))
        {
            source.Stop();
        }
    }
    
}
