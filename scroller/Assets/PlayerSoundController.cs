using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundStates
{
    Shoot,
    Hurt
}

public class PlayerSoundController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundStates _newSound)
    {
        audioSource.clip = clips[(int)_newSound];
        audioSource.Play();
    }
}
