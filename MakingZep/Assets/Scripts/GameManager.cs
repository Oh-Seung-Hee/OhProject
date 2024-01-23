using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CharacterType
{
    Blue,
    Pink
}

[System.Serializable]
public class Character
{
    public CharacterType CharacterType;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController AnimatorController;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Character> CharacterList = new List<Character>();

    public Animator PlayerAnimator;
    public TMP_Text PlayerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCharacter(CharacterType characterType, string name)
    {
        var character = GameManager.Instance.CharacterList.Find(item => item.CharacterType == characterType);

        PlayerAnimator.runtimeAnimatorController = character.AnimatorController;
        PlayerName.text = name;
    }
}
