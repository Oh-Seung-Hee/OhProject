using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    // ī�� ������
    public Animator anim;

    // ī�� �Ҹ�
    public AudioClip flip;
    public AudioSource audioSource;

    // ī�带 ������ ��
    public void openCard()
    {
        // ī�� ������ �Ҹ� ���
        audioSource.PlayOneShot(flip);

        // ī�带 �������� ��
        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        // ������ ī�尡 ù��° ī���
        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        // �ι�° ī���
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }

    // ī�� ����
    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    // ī�� ����
    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    // ī�带 �ٽ� ������
    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    // ī�带 �ٽ� ������
    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
