using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{

    /*
     *     1. ��������=> bool
    ĳ���� �����Ϳ��� �ۼ��� ������ �޾ƿͼ� ������Ʈ�� �ٿ��� ������ ��ũ��Ʈ
    �̵� Ű���� ����Ű

     */

    public Character_Skill character_Skill;


    public bool isDead { get; protected set; }
    private bool isDamaged=false;

    public event Action OnDead;

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
            character_Skill.isSkillUse = false;
            //TODO: ������ + ��ų �������� �ִϸ��̼�
        }
        else
        {
            Die();
            //TODO: ĳ���� �״� �ִϸ��̼�
        }
    }


    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "")
        {
            //TODO: tag�� �������� �ȹ޴� ��ü �� ��� tag ����

        }
        else if (coll.transform.tag == "")
        {
            //TODO: tag�� �������� �޴� ��ü �� ��� tag ���� + ��ų ���� Ȯ��
            Check_Skill();
        }
    }
}
