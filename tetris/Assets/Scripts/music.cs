using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class music: MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
