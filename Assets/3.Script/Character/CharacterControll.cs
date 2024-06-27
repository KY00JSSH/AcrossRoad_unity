using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{

    /*
     *     1. ��������=> bool
    ĳ���� �����Ϳ��� �ۼ��� ������ �޾ƿͼ� ������Ʈ�� �ٿ��� ������ ��ũ��Ʈ

     */

    public Character_Skill character_Skill;


    public bool isDead { get; protected set; }

    public event Action OnDead;
    private void Awake()
    {
        character_Skill = GetComponent<Character_Skill>();
    }

    public void OnEnable()
    {
        isDead = false;
    }
    //��ų��� ���� Ȯ��

    public void Die()
    {
        if (OnDead != null)
        {
            OnDead();
        }
        isDead = true;
    }

    //TODO: �� ���� ��� ��ų ���� ���� �����ϴ� �޼ҵ� �ۼ�
    private void Check_Skill()
    {
        // �нú�
        if (character_Skill.isSkillUse)
        {
            //TODO: ������ + ��ų �������� �ִϸ��̼�
            character_Skill.isSkillUse = false;
            return;
        }
        else
        {
            //TODO: ĳ���� �״� �ִϸ��̼�
            Die();
        }
    }


    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "Obs")
        {
            //TODO: tag�� �������� �ȹ޴� ��ü �� ��� tag ����
            return;
        }
        else if (coll.transform.tag == "DieObs")
        {
            //TODO: tag�� �������� �޴� ��ü �� ��� tag ���� + ��ų ���� Ȯ��
            Check_Skill();
        }
    }
}
