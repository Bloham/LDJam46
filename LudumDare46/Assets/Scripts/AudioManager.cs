using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip click;
    public AudioClip destroy;
    public AudioClip rain;
    public AudioClip sun;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClick()
    {
        playerAudio.PlayOneShot(click, 1.0f);
    }

    public void PlayDestroy()
    {
        playerAudio.PlayOneShot(destroy, 0.8f);
    }

    public void PlayRain()
    {
        playerAudio.PlayOneShot(rain, 1.0f);
    }
    public void PlaySun()
    {
        playerAudio.PlayOneShot(sun, 1.0f);
    }
}
