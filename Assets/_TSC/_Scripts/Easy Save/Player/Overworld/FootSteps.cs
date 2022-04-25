﻿using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private AudioClip[] clips2;


    private AudioSource audioSource;
   

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];

    }
}