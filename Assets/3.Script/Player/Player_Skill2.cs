using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Skill2 : MonoBehaviour
{
    [SerializeField] private PlayerControll playerControll;

    //��ų ��밡�� ǥ�� ��ư?
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
        // ��ư Ŭ���� �ش� �޼�Ʈ ����
        skillAvailable.onClick.AddListener(SkillStart);
    } 
     */
    private IEnumerator DefenceTimeCheck()
    {
        Debug.Log("Player_Skill2 ��ų ���");
        playerControll.isSkillUse = true;
        playerControll.Field.SetActive(true) ;
        yield return new WaitForSeconds(5f); // ���Ⱑ ������ų ���ð�
        playerControll.isSkillUse = false;
        playerControll.Field.SetActive(false);
        Debug.Log("��ų ����");
        playerControll.gaugeTime = 0f; // ��ų�� ������ ������ �ð� �ʱ�ȭ
    }

}
