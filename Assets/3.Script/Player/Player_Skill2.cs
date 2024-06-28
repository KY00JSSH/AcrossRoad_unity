using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill2 : MonoBehaviour
{
    [SerializeField] private PlayerControll playerControll;


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
    

    private IEnumerator DefenceTimeCheck()
    {
        Debug.Log("Player_Skill2 스킬 사용");
        playerControll.isSkillUse = true;
        yield return new WaitForSeconds(5f); // 여기가 무적스킬 사용시간
        playerControll.isSkillUse = false;
        Debug.Log("스킬 꺼짐");
        playerControll.gaugeTime = 0f; // 스킬이 꺼지고 게이지 시간 초기화
    }
    

}
