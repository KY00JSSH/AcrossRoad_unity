using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement[] playerMovement;

    [Header("# InGame")]
    [SerializeField]
    private Text textScore;

    private int selcetedCharacterIndex = 0;

    private void Update()
    {
       if(playerMovement.Length > 0 && selcetedCharacterIndex >= 0 &&
            selcetedCharacterIndex < playerMovement.Length)
        {
            textScore.text = $"Score {playerMovement[selcetedCharacterIndex].score}";
        }
    }

}
