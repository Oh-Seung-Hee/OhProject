using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // 배경음악
    public AudioClip bgmusic;
    public AudioSource audioSource;

    void Start()
    {
        bgmPlay();
    }

    // 배경음악 출력
    void bgmPlay()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }
}
