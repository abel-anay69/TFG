using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer Musica, Efectos;
    public AudioSource hit, kill, jump, fondo, muerte, herido, coin, cura;

    public static AudioManager instance;

    public void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(fondo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio) 
    {
        audio.Play();
    }
}
