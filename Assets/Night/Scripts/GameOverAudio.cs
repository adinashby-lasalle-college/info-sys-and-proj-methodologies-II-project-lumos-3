using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private void OnEnable()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
