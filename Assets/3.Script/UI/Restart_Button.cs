using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Button : MonoBehaviour
{
    RectTransform rect;

    bool isGameOver = true;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        isGameOver = GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rect.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Character_Die_Logo_Appear() //���ӿ����Ǹ� ��ư ��Ÿ����
    {
        if (isGameOver)
        {
            rect.localScale = Vector3.one;
        }
    }

    public void BackTo_MainScene()
    {
        SceneManager.LoadScene(""); //"" <- �ȿ� ���� ���Ӿ� �̸� �ֱ�
    }
}
