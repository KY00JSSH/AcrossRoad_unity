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
        if (playerControll.isSkillUse) //update���� �� ��� Ȯ���ؼ� ��ų ���
        {
            StopCoroutine(DefenceTimeCheck());
            StartCoroutine(DefenceTimeCheck());
        }
    }

    private IEnumerator DefenceTimeCheck()
    {
        Debug.Log("Player_Skill2 ��ų ���");
        playerControll.isSkillUse = true;
        skillEffect.SetActive(true); // ��ų ����Ʈ ����
        yield return new WaitForSeconds(5f); // ���Ⱑ ������ų ���ð�
       // playerControll.isSkillUse = false;
        skillEffect.SetActive(false); // ��ų ����Ʈ  ����
        Debug.Log("��ų ����");
       // playerControll.gaugeTime = 0f; // ������ �ð� �ʱ�ȭ�� Controll���� Ȯ��
    }

}
