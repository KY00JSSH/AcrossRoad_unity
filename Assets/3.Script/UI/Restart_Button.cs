using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Button : MonoBehaviour
{
    RectTransform rect;
    private PlayerControll playerControl; //240629 14:20

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.zero; // 게임오버까지 버튼 숨김
        playerControl = FindObjectOfType<PlayerControll>();//240629 14:20
        if (playerControl != null)
        {
            playerControl.OnDead += Character_Die_Button_Appear;
        }
    }
       
    // Update is called once per frame
    void Update()
    {
        //if (gm.isGameover)
        //{
        //    Character_Die_Button_Appear();
        //    Debug.Log("WOW");
        //}
    }

    private void OnDestroy() //240629 14:20
    {
        if(playerControl != null)
        {
            playerControl.OnDead -= Character_Die_Button_Appear;
        }
    }

    private void Character_Die_Button_Appear() //게임오버되면 버튼 나타나게
    {
        rect.localScale = Vector3.one;        
    }

    public void BackTo_MainScene()
    {
        SceneManager.LoadScene("AcrossGame"); // 버튼 누르면 메인씬으로 돌아가기
    }
}
