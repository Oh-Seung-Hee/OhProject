using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // �������
    public AudioClip bgmusic;
    public AudioSource audioSource;

    void Start()
    {
        bgmPlay();
    }

    // ������� ���
    void bgmPlay()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }
}
