using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    /*
     *     1. ��������=> bool
    ĳ���� �����Ϳ��� �ۼ��� ������ �޾ƿͼ� ������Ʈ�� �ٿ��� ������ ��ũ��Ʈ    
        //TODO: ��ų bool ���� �ϰ� �� ���� �ѱ�� �ش� ��ų ��ũ��Ʈ���� �����
     */
    private Animator dieAni;
    public bool isSkillPassive;

    // ��ų Ȯ��
    public bool isSkillUse;
    public float gaugeTime = 0f;


    public bool isDead { get; protected set; }

    public event Action OnDead;
    public event Action SkillStart;

    private void Awake()
    {
        dieAni = GetComponent<Animator>();
        gaugeTime = 55f;

    }

    public void OnEnable()
    {
        isDead = false;
    }

    private void Update()
    {
        gaugeTime += Time.deltaTime;

        if (gaugeTime>=20f)
        {
            //Debug.Log("��ų ��� ����");
        }

        if (isSkillPassive)
        {
            Skill_Passive_Input();
        }
        else 
        {
            Skill_Active_Input();
        }
    }

    private void Check_Skill()
    {
        if (isSkillUse)
        {
            Debug.Log(isSkillUse);
            if (isSkillPassive)
            {
                Debug.Log(isSkillPassive);
                isSkillUse = false;
                gaugeTime = 0f;
            }
            return;
        }
        else
        {
            Die();
        }
    }

    // ��ų �Է� �޴� �κ�
    private void Skill_Active_Input()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSkillUse == false && gaugeTime>=20f)
        {
            if (SkillStart != null)
            {
                SkillStart();
            }
            Debug.Log("��ų ���");
            isSkillUse = true;
            gaugeTime = 0f;
        }
    }

    private void Skill_Passive_Input()
    {
        if (isSkillPassive && gaugeTime >= 20f)
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
