using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    /*
     *     1. 생존여부=> bool
    캐릭터 데이터에서 작성한 정보를 받아와서 오브젝트에 붙여서 실행할 스크립트    
        //TODO: 스킬 bool 제어 하고 그 값을 넘기면 해당 스킬 스크립트에서 스킬 사용 + 이펙트 활성화
     */

    public bool isDead { get; protected set; }
    public event Action OnDead;

    // 스킬 사용해서 넘겨줘야하는 값
    public bool isSkillUse;

    public bool isSkillPassive;

    // 업데이트에서 게이지는 시간 추가 -> 스킬 사용 후 게이지값 초기화
    public float gaugeTime = 0f;

    public void Awake()
    {
        gaugeTime = 10f;
    }

    private void Update()
    {
        if (isSkillPassive)
        {
            // 패시브일 경우 일단 계속 시간 확인해서 스킬 켜야함
            Skill_Passive_On();
        }
        else
        {//  패시브가 아닐경우 
            // 초기화
            Time_SkillUse_Clear();
            // 스킬 사용 변경 메소드
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
        //스킬 사용과 게이지 시간이 넘었으면 초기화
        if (isSkillUse && gaugeTime >= 5f)
        {
            gaugeTime = 0f;
            isSkillUse = false;
            Debug.Log("스킬 사용 / 게이지 시간 초기화 완료 위치");
        }
    }

    private void Skill_Active_On()
    {
        // 스킬 입력 받는 부분
        if (Input.GetKeyDown(KeyCode.R) && isSkillUse == false && gaugeTime >= 5f)
        {
            Debug.Log("스킬 사용");
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
        Debug.Log("캐릭터 죽음");
        if (OnDead != null)
        {
            OnDead();
        }
        isDead = true;
        transform.gameObject.SetActive(false);
    }


}
