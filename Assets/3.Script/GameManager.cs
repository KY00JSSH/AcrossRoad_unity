using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱��� 1��° ���� - (����) �ν��Ͻ� ��ȣ
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
        }
    }
    public bool isGameover { get; private set; }
    public int Score = 0;

    private void Start()
    {

    }

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
}