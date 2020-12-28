using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController i;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioclip;

    //private static float vol = 1f;

    void Awake()
    {
        i = this;
    }
    public void PlayAudio(int id)
    {
        audioSource.PlayOneShot(audioclip[id]);
    }
    public void PlayAudio(int id, float vol)
    {
        audioSource.PlayOneShot(audioclip[id], vol);
    }
}
