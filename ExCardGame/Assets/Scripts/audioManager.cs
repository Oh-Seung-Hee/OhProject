using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // 배경음악
    public AudioSource bgm;

    // 시간 경고음 사운드
    public AudioSource beep;

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
        bgm.Play();
    }

    // 시간 경고음 사운드 출력
    void beepPlay()
    {
        if (gameManager.I.isBeep)
        {
            if (!beep.isPlaying)
            {
                beep.Play();
            }
        }
    } 
}
