using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{

    /*
     스킬 패시브
    => 시간경과에 따라 자동으로 스킬이 켜짐
    스킬 액티브
      => 키보드가 눌리면 스킬이 켜짐
    
    스킬이 꺼져 있을 경우 update에서 패시브인지 액티브인지에 따라 스킬이 꺼져있는지 확인
    꺼져있을 경우 스킬이 입력되는지 확인 후 bool 값 던질것

     */


    // 캐릭터 특성 받아오기
    public Player_Data character_Data;
    private float skillUseTime;
    private float gaugeTime = 0f;

    // 스킬 확인
    public bool isSkillUse;
    [SerializeField] private KeyCode SkillUse = KeyCode.F;

    private void Awake()
    {
        // 스킬이 패시브일때 스킬사용 중
        if (character_Data.isSkillPassive)
        {
            Debug.Log("스킬 사용 패시브 on");
            isSkillUse = true;
        }
    }

    private void Update()
    {
        gaugeTime += Time.deltaTime;
      
        if (character_Data.isSkillPassive)
        {// 스킬이 패시브이면 스킬이 꺼져있을 경우 게이지 시간 지남에 따라 스킬 재가동

            if (!isSkillUse && gaugeTime >= 50f)
            {
                isSkillUse = true;
                gaugeTime = 0f;
                Debug.Log("스킬 사용 패시브 재사용");
            }
        }
        else
        {
            
            if (character_Data.isDefence)
            {
                if (Skill_Input() && gaugeTime >= 50f) // 50초 후 사용가능
                {
                    Debug.Log("isDefence 스킬 사용 확인");
                    // 무적상태일 경우 5초 후 스킬 꺼야함 
                    StartCoroutine(DefenceTimeCheck());
                }
            }
            else if(character_Data.isDelete)
            {
                //TODO: 그 장애물 삭제하는 능력 넣어야함 : 大홍현
            }
        }
    }

    private IEnumerator DefenceTimeCheck()
    {
        //TODO: 실험 시간 20초 변경할 것
        isSkillUse = true;
        Debug.Log("스킬 켜짐" + gaugeTime);
        yield return new WaitForSeconds(20f); // 여기가 무적스킬 사용시간
        isSkillUse = false;
        gaugeTime = 0f; // 스킬이 꺼지고 게이지 시간 초기화
        Debug.Log("스킬 꺼짐" + gaugeTime);
    }

    private bool Skill_Input()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSkillUse == false)
        {
            isSkillUse = true;
            Debug.Log("스킬 사용 키보드 F");
            return true;
        }
        return false;
    }
    

}
