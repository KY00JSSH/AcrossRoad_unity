using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Skill2 : MonoBehaviour
{
    [SerializeField] private PlayerControll playerControll;
    public GameObject skillEffect;

    private void Awake()
    {
        playerControll = GetComponent<PlayerControll>();
    }
    private void Update()
    {
        skillEffect.transform.position = transform.position;
        if (playerControll.isSkillUse) //update에서 값 계속 확인해서 스킬 사용
        {
            StopCoroutine(DefenceTimeCheck());
            StartCoroutine(DefenceTimeCheck());
        }
    }

    private IEnumerator DefenceTimeCheck()
    {
        Debug.Log("Player_Skill2 스킬 사용");
        playerControll.isSkillUse = true;
        skillEffect.SetActive(true); // 스킬 이펙트 켜짐
        yield return new WaitForSeconds(5f); // 여기가 무적스킬 사용시간
       // playerControll.isSkillUse = false;
        skillEffect.SetActive(false); // 스킬 이펙트  꺼짐
        Debug.Log("스킬 꺼짐");
       // playerControll.gaugeTime = 0f; // 게이지 시간 초기화는 Controll에서 확인
    }

}
