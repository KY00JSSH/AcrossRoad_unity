using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    /*
     *     1. ��������=> bool
    ĳ���� �����Ϳ��� �ۼ��� ������ �޾ƿͼ� ������Ʈ�� �ٿ��� ������ ��ũ��Ʈ    
        //TODO: ��ų bool ���� �ϰ� �� ���� �ѱ�� �ش� ��ų ��ũ��Ʈ���� ��ų ��� + ����Ʈ Ȱ��ȭ
     */

    public bool isDead { get; protected set; }
    public event Action OnDead;

    // ��ų ����ؼ� �Ѱ�����ϴ� ��
    public bool isSkillUse;

    public bool isSkillPassive;

    // ������Ʈ���� �������� �ð� �߰� -> ��ų ��� �� �������� �ʱ�ȭ
    public float gaugeTime = 0f;

    public void Awake()
    {
        gaugeTime = 10f;
    }

    private void Update()
    {
        if (isSkillPassive)
        {
            // �нú��� ��� �ϴ� ��� �ð� Ȯ���ؼ� ��ų �Ѿ���
            Skill_Passive_On();
        }
        else
        {//  �нú갡 �ƴҰ�� 
            // �ʱ�ȭ
            Time_SkillUse_Clear();
            // ��ų ��� ���� �޼ҵ�
            Skill_Active_On();
        }
        gaugeTime += Time.deltaTime;
      
    }
    public void OnEnable()
    {
        isDead = false;
    }


    private void Time_SkillUse_Clear()
    {
        //��ų ���� ������ �ð��� �Ѿ����� �ʱ�ȭ
        if (isSkillUse && gaugeTime >= 5f)
        {
            gaugeTime = 0f;
            isSkillUse = false;
            Debug.Log("��ų ��� / ������ �ð� �ʱ�ȭ �Ϸ� ��ġ");
        }
    }

    private void Skill_Active_On()
    {
        // ��ų �Է� �޴� �κ�
        if (Input.GetKeyDown(KeyCode.R) && isSkillUse == false && gaugeTime >= 5f)
        {
            Debug.Log("��ų ���");
            isSkillUse = true;
            gaugeTime = 0f;
        }
    }

    private void Skill_Passive_On()
    {
        if (gaugeTime >= 5f)
        {
            isSkillUse = true;
        }
    }





    // ��ֹ� tag���ؼ� ĳ���Ͱ� �������� ������ �� ������ ����
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "Obs")
        {
            Debug.Log(coll.transform.tag);
            return;
        }
        else if (coll.transform.tag == "DieObs")
        {
            Debug.Log(coll.transform.tag);
            Check_Skill();
        }
    }

    private void Check_Skill()
    {
        if (!isSkillUse)
        {
            Die();
        }
        else
        {
            if (isSkillPassive)
            {
                Debug.Log(isSkillPassive);
                isSkillUse = false;
                gaugeTime = 0f;
            }
            return;
        }
    }



    public void Die()
    {
        Debug.Log("ĳ���� ����");
        if (OnDead != null)
        {
            OnDead();
        }
        isDead = true;
        transform.gameObject.SetActive(false);
    }


}
