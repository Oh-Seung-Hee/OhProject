using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    // 카드 움직임
    public Animator anim;

    // 카드 소리
    public AudioClip flip;
    public AudioSource audioSource;

    // 카드 색 변환
    SpriteRenderer cardColor;
    public GameObject clickedCard;

    void Start()
    {
        cardColor = clickedCard.GetComponent<SpriteRenderer>();
    }

    // 카드를 뒤집을 때
    public void openCard()
    {
        // 카드 뒤집는 소리 출력
        audioSource.PlayOneShot(flip);

        // 카드를 뒤집었을 때
        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        // 뒤집은 카드가 첫번째 카드면
        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        // 두번째 카드면
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }

    // 카드 제거
    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    // 카드 제거
    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    // 카드를 다시 뒤집음
    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    // 카드를 다시 뒤집음
    void closeCardInvoke()
    {
        // 카드 다시 뒤집음
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);

        // 뒤집었던 카드 색 변경
        changeColor();
    }

    // 뒤집었던 카드 색 변경
    void changeColor()
    {
        cardColor.material.color = new Color(192 / 255f, 192 / 255f, 192 / 255f);
    }
}
