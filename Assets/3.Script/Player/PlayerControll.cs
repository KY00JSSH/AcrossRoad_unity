using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    /*
    ĳ���� �����Ϳ��� �ۼ��� ������ �޾ƿͼ� ������Ʈ�� �ٿ��� ������ ��ũ��Ʈ    

    1. tag�� ��ֹ� ������ ���� Ȯ��

    2. ��ų �нú� ��Ƽ�� Ȯ��
        2-1. �нú� : ��ų ���� Ȱ��ȭ => OnCollisionEnter���� tagȮ�� �� ��ų off 
        2-2. ��Ƽ�� : Ű���� input Ȥ�� button.onclickȮ�� �� ��ų Ȱ��ȭ bool 

    3. gaugetime ����
        - �ʱ� ���� : gaugetime ���� 10���� �����Ͽ� ��ų ��� ���� 
        - update���� ��ų ��� isSkillUse + gaugetime 5�� �̻�� (gaugetime + isSkillUse) �ʱ�ȭ 

        //TODO: ��ų bool ���� �ϰ� �� ���� �ѱ�� �ش� ��ų ��ũ��Ʈ���� ��ų ��� + ����Ʈ Ȱ��ȭ
     */

    public bool isDead { get; protected set; }
    public event Action OnDead;

    // ��ư���� ��ų ���
    public Button SkillButton;
    public Sprite ButtonSprite;

    // ��ų ����ؼ� �Ѱ�����ϴ� ��
    public bool isSkillUse;
    public bool isSkillPassive;

    // ������Ʈ���� �������� �ð� �߰� -> ��ų ��� �� �������� �ʱ�ȭ
    public float gaugeTime = 0f;

    private AudioManager audioManager;

    public void Awake()
    {
        gaugeTime = 15f;
        if (SkillButton != null)
        {
            SkillButton.gameObject.SetActive(true);
            SkillButton.gameObject.GetComponent<Image>().sprite = ButtonSprite;
        }
        audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (isSkillPassive)
        {
            // �нú��� ��� �ϴ� ��� �ð� Ȯ���ؼ� ��ų �Ѿ���
            Skill_Passive_On();
            SkillButton.enabled = false; // �нú��� ��� ��ư Ȱ��ȭ�� �Ǿ������� ��� �Ұ�
        }
        else
        {//  �нú갡 �ƴҰ�� 
            // ��ų ��� ���� �޼ҵ�
            Skill_Active_On();
            if (isSkillUse == false && gaugeTime >=10)
            {
                //������ �ð��� á�� ��� ��ư Ȱ��ȭ ���ð���
                SkillButton.gameObject.SetActive(true);
                SkillButton.onClick.AddListener(Skill_Active_Button_Use_On);
            }
            // �ʱ�ȭ
            Time_SkillUse_Clear();
        }
        gaugeTime += Time.deltaTime;
      
    }
    public void OnEnable()
    {
        isDead = false;
    }


    private void Time_SkillUse_Clear()
    {
        //��ų ���� ��� �ð��� �Ѿ����� �ʱ�ȭ
        if (isSkillUse && gaugeTime >= 2f)
        {
            gaugeTime = 0f;
            isSkillUse = false;
            SkillButton.gameObject.SetActive(false);
            Debug.Log("��ų ��� / ������ �ð� �ʱ�ȭ �Ϸ� ��ġ");
        }
    }

    private void Skill_Active_On()
    {
        // ��ų �Է� �޴� �κ�
        if (Input.GetKeyDown(KeyCode.R) && isSkillUse == false && gaugeTime >= 10f)
        {
            Debug.Log("��ų ���");
            isSkillUse = true;
            gaugeTime = 0f;
            SkillButton.gameObject.SetActive(false); // ��ų ��� �� ��ư ��Ȱ��ȭ
            // SkillButton.gameObject.SetActive(false); // ��ų ��� �� ��ư ��Ȱ��ȭ
            audioManager.PlaySkillSound();
        }
    }

    private void Skill_Active_Button_Use_On()
    {
        Debug.Log("��ư���� ��ų ���");
        isSkillUse = true;
        gaugeTime = 0f;
        SkillButton.gameObject.SetActive(false); // ��ų ��� �� ��ư ��Ȱ��ȭ
        //SkillButton.gameObject.SetActive(false); // ��ų ��� �� ��ư ��Ȱ��ȭ
        audioManager.PlaySkillSound();
    }

    private void Skill_Passive_On()
    {
        if (gaugeTime >= 10f)
        {
            isSkillUse = true;
            SkillButton.gameObject.SetActive(true);
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
                SkillButton.gameObject.SetActive(false); // ��ų1�� ���� �� ��ư ��Ȱ��ȭ
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
