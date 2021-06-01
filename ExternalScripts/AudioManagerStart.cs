﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerStart : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManagerStart instance;
    public bool mute;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 7)
        //{
            DontDestroyOnLoad(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);

        foreach (Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();

            item.source.clip = item.clip;
            item.source.volume = item.volume;
            //item.source.pitch = item.pitch;
            item.source.loop = item.loop;

        }
    }

    public void Play(string name)
    {
        if (!mute)
        {
            Sound item = Array.Find(sounds, sound => sound.name == name);
            if (item == null)
            {
                Debug.LogWarning("Sound" + name + " not found");
                return;
            }
            item.source.Play();
        }


    }


    public void Stop(string name)
    {
        Sound item = Array.Find(sounds, sound => sound.name == name);
        if (item == null)
        {
            Debug.LogWarning("Sound" + name + " not found");
            return;
        }
        item.source.Stop();
        //item.source.

    }

    public void Pause(string name)
    {
        Sound item = Array.Find(sounds, sound => sound.name == name);
        if (item == null)
        {
            Debug.LogWarning("Sound" + name + " not found");
            return;
        }
        if (item.source.isPlaying)
        {
            item.source.Pause();
        }
        
        //item.source.isPlaying

    }
}////////
