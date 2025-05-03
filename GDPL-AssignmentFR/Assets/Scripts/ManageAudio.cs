using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAudio : MonoBehaviour
{
    [SerializeField] private AudioSource bkgSource;

    [SerializeField] private AudioSource SFXSource;

    [SerializeField] private AudioClip music;


    private void Start()
    {
        bkgSource.clip = music;

        bkgSource.Play();
    }
    public void PlaySFX(AudioClip sfx) //Plays sound effect
    {
        SFXSource.PlayOneShot(sfx);
    }
}


