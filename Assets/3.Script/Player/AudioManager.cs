using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip moveSound; 
    public AudioClip skillSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayMoveSound()
    {
        if (moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.Play();
        }
    }

    public void PlaySkillSound()
    {
        if (skillSound != null)
        {
            audioSource.clip = skillSound;
            audioSource.Play();
        }
    }
}
