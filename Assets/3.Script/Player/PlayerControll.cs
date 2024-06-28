using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    /*
     *     1. 생존여부=> bool
    캐릭터 데이터에서 작성한 정보를 받아와서 오브젝트에 붙여서 실행할 스크립트    
        //TODO: 스킬 bool 제어 하고 그 값을 넘기면 해당 스킬 스크립트에서 사용함
     */
    private Animator dieAni;
    public bool isSkillPassive;

    // 스킬 확인
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
            //Debug.Log("스킬 사용 가능");
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

    // 스킬 입력 받는 부분
    private void Skill_Active_Input()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSkillUse == false && gaugeTime>=20f)
        {
            if (SkillStart != null)
            {
                SkillStart();
            }
            Debug.Log("스킬 사용");
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
    // 장애물 tag통해서 캐릭터가 데미지를 받을지 안 받을지 결정
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

        Debug.Log("캐릭터 죽음");
        if (OnDead != null)
        {
            OnDead();
        }
        isDead = true;
        transform.gameObject.SetActive(false);
    }


}
