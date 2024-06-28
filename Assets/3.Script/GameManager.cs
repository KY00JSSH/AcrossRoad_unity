using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            //return;
        }
    }

    public bool isGameover { get; private set; }
    public int Score = 0;

    public bool isTimePassing; //일시정지를 위한 bool값 240628 13:16

    public void EndGame()
    {
        isGameover = true;
        //  UIController.instance.SetActiveGameOver(true);
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            Score += newScore;
            // UIController.instance.updateScore(Score);
        }
    }

    private void Update()
    {
        Time.timeScale = isTimePassing ? 1 : 0; //일시정지 버튼 토글 240628 13:16
    }
}