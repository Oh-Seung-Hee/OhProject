using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // �������
    public AudioSource bgm;

    // �ð� ����� ����
    public AudioSource beep;

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
        bgm.Play();
    }

    // �ð� ����� ���� ���
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
