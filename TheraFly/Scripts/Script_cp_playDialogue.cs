using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_cp_playDialogue : MonoBehaviour
{
    //public AudioClip dialogue;
    public AudioSource audiosource;
   // public float volume = 1f;
    //public float pitch = 1f;

    private AudioSource audioSource;
    //private GameObject newDialogue;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = dialogue;
        //audioSource.volume = volume;
        //audioSource.pitch = pitch;

        audioSource.playOnAwake = false;
        //newDialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        //newDialogue.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
        //newDialogue.SetActive(true);
    }
}
