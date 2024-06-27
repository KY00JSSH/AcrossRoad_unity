using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{

    /*
     *     1. ��������=> bool
    ĳ���� �����Ϳ��� �ۼ��� ������ �޾ƿͼ� ������Ʈ�� �ٿ��� ������ ��ũ��Ʈ    
        //TODO: ��õ����� Ȱ��ȭ�� �Ǵ��� �ʱ�ȭ�� �Ǵ��� Ȯ���ؾ���
        //TODO: ��ü �ִϸ��̼� �Ⱥٿ���
     */

    private Character_Skill character_Skill;


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
        //TODO: coll.transform.tag == "DieObs" �� ��� ��Ȱ��ȭ Ȯ�� => ���� ������ �Ѿ����
        transform.gameObject.SetActive(false);
        isDead = true;
    }

    private void Check_Skill()
    {
        // ��ų ��� ���� Ȯ���ϴ� �޼ҵ�
        Debug.Log("Check_Skill ����"+ character_Skill.isSkillUse);
        // �нú�
        if (character_Skill.isSkillUse)
        {
            //TODO: ������ + ��ų �������� �ִϸ��̼�
            if (character_Skill.character_Data.isSkillPassive)
            {
                character_Skill.isSkillUse = false;
            }
            return;
        }
        else
        {
            //TODO: ĳ���� �״� �ִϸ��̼�
            Die();
        }
    }

    // ��ֹ� tag���ؼ� ĳ���Ͱ� �������� ������ �� ������ ����
    private void OnCollisionEnter(Collision coll)
    {
        //TODO: tag�� Ȯ�� �����ϳ� ��ü�� ���Ʒ� ���Ͽ� �հ� ������ �����ʿ���
        if (coll.transform.tag == "Obs")
        {
            return;
        }
        else if (coll.transform.tag == "DieObs")
        {
            Check_Skill();
        }
    }
}
