using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // 배경음악
    public AudioClip bgmusic;
    public AudioSource audioSource;

    // 시간 경고음 사운드
    public AudioClip timeAlarm;

    void Start()
    {
        bgmPlay();
    }

    void Update()
    {
        beepPlay();
    }

    // 배경음악 출력
    void bgmPlay()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    // 시간 경고음 사운드 출력
    void beepPlay()
    {
        if (gameManager.I.isBeep)
        {
            audioSource.PlayOneShot(timeAlarm, 0.4f);
        }
    }
}
