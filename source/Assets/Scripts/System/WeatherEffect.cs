using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffect : MonoBehaviour
{
    public ParticleSystem effect;
    public AudioSource audio;

    public void PlayParticle(ParticleSystem targetParticle)
    {
        if(effect != null) Destroy(effect);
        effect = Instantiate(targetParticle, transform.position + Vector3.up * 10f, Quaternion.identity);
        effect.Play();
    }

    public void PlayAudio(AudioClip targetAudio)
    {
        if(audio != null) Destroy(audio);
        audio.clip = targetAudio;
        audio.Play();
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
}
