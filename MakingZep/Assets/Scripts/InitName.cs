using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitName : MonoBehaviour
{
    [SerializeField] private Image characterSprite;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject initPlayer;
    [SerializeField] private GameObject selectCharacter;

    private CharacterType characterType;

    public void OnClickCharacter()
    {
        initPlayer.SetActive(false);
        selectCharacter.SetActive(true);
    }

    public void OnClickSelectCharacter(int index)
    {
        characterType = (CharacterType)index;
        var character = GameManager.Instance.CharacterList.Find(item => item.CharacterType == characterType);

        characterSprite.sprite = character.CharacterSprite;
        characterSprite.SetNativeSize();

        selectCharacter.SetActive(false);
        initPlayer.SetActive(true);
    }

    public void OnClickJoin()
    {
        if (!(1 < inputField.text.Length && inputField.text.Length < 11))
        {
            return;
        }

        GameManager.Instance.SetCharacter(characterType, inputField.text);

        Destroy(gameObject);
    }
}
