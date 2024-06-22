using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] ExplodeSounds;
    [SerializeField] private AudioClip shootSFXs;
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void OnBulletFired()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSFXs);
    }

    public void OnExplode(int index)
    {
        GetComponent<AudioSource>().PlayOneShot(ExplodeSounds[index]);
    }
}
