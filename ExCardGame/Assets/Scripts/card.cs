using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    // 카드 움직임
    public Animator anim;

    // 카드를 뒤집을 때
    public void openCard()
    {
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
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
