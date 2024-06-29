using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Skill2 : MonoBehaviour
{
    [SerializeField] private PlayerControll playerControll;

    //스킬 사용가능 표시 버튼?
    public Button skillAvailable;

    private void Awake()
    {
        playerControll = GetComponent<PlayerControll>();

    }
    private void Start()
    {
        playerControll.SkillStart += SkillStart;
    }

    private void SkillStart()
    {
        StartCoroutine(DefenceTimeCheck());
    }

    /*
     
    private void Update()
    {
        // 버튼 클릭시 해당 메소트 실행
        skillAvailable.onClick.AddListener(SkillStart);
    } 
     */
    private IEnumerator DefenceTimeCheck()
    {
        Debug.Log("Player_Skill2 스킬 사용");
        playerControll.isSkillUse = true;
        playerControll.Field.SetActive(true) ;
        yield return new WaitForSeconds(5f); // 여기가 무적스킬 사용시간
        playerControll.isSkillUse = false;
        playerControll.Field.SetActive(false);
        Debug.Log("스킬 꺼짐");
        playerControll.gaugeTime = 0f; // 스킬이 꺼지고 게이지 시간 초기화
    }

}
