using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Skill : MonoBehaviour
{

    /*
     ��ų �нú�
    => �ð������ ���� �ڵ����� ��ų�� ����
    ��ų ��Ƽ��
      => Ű���尡 ������ ��ų�� ����
    
    ��ų�� ���� ���� ��� update���� �нú����� ��Ƽ�������� ���� ��ų�� �����ִ��� Ȯ��
    �������� ��� ��ų�� �ԷµǴ��� Ȯ�� �� bool �� ������


     */


    // ĳ���� Ư�� �޾ƿ���
    public Character_Data character_Data;
    private float time;

    // ��ų Ȯ��
    public bool isSkillUse;
    [SerializeField] private KeyCode SkillUse = KeyCode.F;

    private void Awake()
    {
        // ��ų�� �нú��϶� ��ų��� ��
        if (character_Data.isSkillPassive)
        {
            isSkillUse = true;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (character_Data.isSkillPassive)
        {// ��ų�� �нú��̸� ��ų�� �������� ��� �ð� ������ ���� ��ų �簡��

            //TODO: ��ų�� �нú��� ��� ������ ä������ ��� Ȯ�� �ʿ���(�нú갡 �ð��� �������� Ȯ���ؾ���)
            if (!isSkillUse && time>=5)
            {
                isSkillUse = true;
                time = 0f;
            }
        }
        else
        {
            if (character_Data.isDefence)
            {
                // 
            }
            else
            {
                //TODO: �� ��ֹ� �����ϴ� �ɷ� �־����
            }
        }
    }

    private void Skill_Input()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isSkillUse = true;
        }
    }
    

}
