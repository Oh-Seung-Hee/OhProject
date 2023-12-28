using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // �������
    public AudioClip bgmusic;
    public AudioSource audioSource;

    // �ð� ����� ����
    public AudioClip timeAlarm;

    void Start()
    {
        bgmPlay();
    }

    void Update()
    {
        beepPlay();
    }

    // ������� ���
    void bgmPlay()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    // �ð� ����� ���� ���
    void beepPlay()
    {
        if (gameManager.I.isBeep)
        {
            audioSource.PlayOneShot(timeAlarm, 0.4f);
        }
    }
}
