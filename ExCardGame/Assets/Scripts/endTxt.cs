using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endTxt : MonoBehaviour
{
    // 게임 재시작
    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
