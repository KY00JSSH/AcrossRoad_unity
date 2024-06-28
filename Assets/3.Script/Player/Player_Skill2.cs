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
        Debug.Log("Player_Skill2 ��ų ���");
        playerControll.isSkillUse = true;
        yield return new WaitForSeconds(5f); // ���Ⱑ ������ų ���ð�
        playerControll.isSkillUse = false;
        Debug.Log("��ų ����");
        playerControll.gaugeTime = 0f; // ��ų�� ������ ������ �ð� �ʱ�ȭ
    }
    

}
