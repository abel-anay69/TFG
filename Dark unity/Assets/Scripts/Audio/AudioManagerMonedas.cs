using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManagerMonedas : MonoBehaviour
{    
    public static AudioManagerMonedas Instance
    {
        get;
        private set;
    }
    private AudioSource audioSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Hay mas de un AudioManager en escema");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
