using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
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
    public Player_Data character_Data;
    private float skillUseTime;
    private float gaugeTime = 0f;

    // ��ų Ȯ��
    public bool isSkillUse;
    [SerializeField] private KeyCode SkillUse = KeyCode.F;

    private void Awake()
    {
        // ��ų�� �нú��϶� ��ų��� ��
        if (character_Data.isSkillPassive)
        {
            Debug.Log("��ų ��� �нú� on");
            isSkillUse = true;
        }
    }

    private void Update()
    {
        gaugeTime += Time.deltaTime;
      
        if (character_Data.isSkillPassive)
        {// ��ų�� �нú��̸� ��ų�� �������� ��� ������ �ð� ������ ���� ��ų �簡��

            if (!isSkillUse && gaugeTime >= 50f)
            {
                isSkillUse = true;
                gaugeTime = 0f;
                Debug.Log("��ų ��� �нú� ����");
            }
        }
        else
        {
            
            if (character_Data.isDefence)
            {
                if (Skill_Input() && gaugeTime >= 50f) // 50�� �� ��밡��
                {
                    Debug.Log("isDefence ��ų ��� Ȯ��");
                    // ���������� ��� 5�� �� ��ų ������ 
                    StartCoroutine(DefenceTimeCheck());
                }
            }
            else if(character_Data.isDelete)
            {
                //TODO: �� ��ֹ� �����ϴ� �ɷ� �־���� : ��ȫ��
            }
        }
    }

    private IEnumerator DefenceTimeCheck()
    {
        //TODO: ���� �ð� 20�� ������ ��
        isSkillUse = true;
        Debug.Log("��ų ����" + gaugeTime);
        yield return new WaitForSeconds(20f); // ���Ⱑ ������ų ���ð�
        isSkillUse = false;
        gaugeTime = 0f; // ��ų�� ������ ������ �ð� �ʱ�ȭ
        Debug.Log("��ų ����" + gaugeTime);
    }

    private bool Skill_Input()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSkillUse == false)
        {
            isSkillUse = true;
            Debug.Log("��ų ��� Ű���� F");
            return true;
        }
        return false;
    }
    

}
