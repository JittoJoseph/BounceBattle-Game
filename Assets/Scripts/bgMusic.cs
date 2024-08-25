using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusic : MonoBehaviour
{

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        audioSource.volume = savedVolume;
    }
}
