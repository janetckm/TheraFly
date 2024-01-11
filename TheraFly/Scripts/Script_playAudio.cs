using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_playAudio : MonoBehaviour
{
    public AudioClip footStep;
    public float volume = 1f;
    public float pitch = 1f;

    private AudioSource audioSource;
    //private GameObject newDialogue;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = footStep;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
}
