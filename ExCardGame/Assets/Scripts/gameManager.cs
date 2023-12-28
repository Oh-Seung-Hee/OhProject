using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class gameManager : MonoBehaviour
{
    // 싱글톤화
    public static gameManager I;

    // 카드 오브젝트
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;

    // 매치 성공 메세지
    public GameObject successTxt;
    public GameObject failTxt;

    // 매치 사운드
    public AudioSource audioSource;
    public AudioClip successSound;
    public AudioClip failSound;

    // 게임 시작 사운드
    public AudioClip startGame;

    // 타임 오브젝트
    public TMP_Text timeTxt;
    float time = 0.0f;

    // 게임 종료 텍스트
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

    // 게임 초기화
    void initGame()
    {
        // 시간 흐름 초기화
        Time.timeScale = 1.0f;

        // 게임 시작 사운드 출력
        audioSource.PlayOneShot(startGame);
    }

    // 타이머 소수 둘째자리까지 표시
    void timer()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    // 시간 초과 게임 오버
    void timeOut()
    {
        if (time >= 30.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    // 카드 생성
    void createCards()
    {
        // 카드 짝 맞추고 섞기
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        // 카드 배열하기
        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            // 섞은 카드 그림 불러오기
            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // 카드 비교하기
    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        // 첫번째 그림과 두번째 그림이 같으면
        if (firstCardImage == secondCardImage)
        {
            // 매치 성공 사운드 출력
            audioSource.PlayOneShot(successSound);

            // 매치 성공한 카드 제거
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            // 남은 카드가 2장 일 때
            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }

            // 매치 성공시 메세지
            successTxt.SetActive(true);
            Invoke("successInvoke", 0.3f);
        }
        // 카드의 그림이 같지 않으면
        else
        {
            // 매치 실패 사운드 출력
            audioSource.PlayOneShot(failSound);

            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();

            // 메치 실패시 메세지
            failTxt.SetActive(true);
            Invoke("failInvoke", 0.3f);
        }

        // 첫번째 카드, 두번째 카드 초기화
        firstCard = null;
        secondCard = null;
    }

    // 매치 성공 메세지 삭제
    void successInvoke()
    {
        successTxt.SetActive(false);
    }

    // 매치 실패 메세지 삭제
    void failInvoke()
    {
        failTxt.SetActive(false);
    }
}
