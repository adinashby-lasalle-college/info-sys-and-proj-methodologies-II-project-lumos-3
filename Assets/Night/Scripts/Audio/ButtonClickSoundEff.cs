using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSoundEff : MonoBehaviour
{
    AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerSound()
    {
        audioSource.Play();
    }
}
