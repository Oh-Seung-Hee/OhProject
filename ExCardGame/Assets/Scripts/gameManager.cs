using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class gameManager : MonoBehaviour
{
    // �̱���ȭ
    public static gameManager I;

    // ī�� ������Ʈ
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;

    // ��ġ ���� �޼���
    public GameObject successTxt;
    public GameObject failTxt;

    // ��ġ ����
    public AudioSource audioSource;
    public AudioClip successSound;
    public AudioClip failSound;

    // ���� ���� ����
    public AudioClip startGame;

    // Ÿ�� ������Ʈ
    public TMP_Text timeTxt;
    float time = 0.0f;

    // ���� ���� �ؽ�Ʈ
    public GameObject endTxt;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        initGame();
        createCards();
    }

    void Update()
    {
        timer();
        timeOut();
    }

    // ���� �ʱ�ȭ
    void initGame()
    {
        // �ð� �帧 �ʱ�ȭ
        Time.timeScale = 1.0f;

        // ���� ���� ���� ���
        audioSource.PlayOneShot(startGame);
    }

    // Ÿ�̸� �Ҽ� ��°�ڸ����� ǥ��
    void timer()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    // �ð� �ʰ� ���� ����
    void timeOut()
    {
        if (time >= 30.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    // ī�� ����
    void createCards()
    {
        // ī�� ¦ ���߰� ����
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        // ī�� �迭�ϱ�
        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            // ���� ī�� �׸� �ҷ�����
            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // ī�� ���ϱ�
    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        // ù��° �׸��� �ι�° �׸��� ������
        if (firstCardImage == secondCardImage)
        {
            // ��ġ ���� ���� ���
            audioSource.PlayOneShot(successSound);

            // ��ġ ������ ī�� ����
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            // ���� ī�尡 2�� �� ��
            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }

            // ��ġ ������ �޼���
            successTxt.SetActive(true);
            Invoke("successInvoke", 0.3f);
        }
        // ī���� �׸��� ���� ������
        else
        {
            // ��ġ ���� ���� ���
            audioSource.PlayOneShot(failSound);

            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();

            // ��ġ ���н� �޼���
            failTxt.SetActive(true);
            Invoke("failInvoke", 0.3f);
        }

        // ù��° ī��, �ι�° ī�� �ʱ�ȭ
        firstCard = null;
        secondCard = null;
    }

    // ��ġ ���� �޼��� ����
    void successInvoke()
    {
        successTxt.SetActive(false);
    }

    // ��ġ ���� �޼��� ����
    void failInvoke()
    {
        failTxt.SetActive(false);
    }
}
