using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Skill : MonoBehaviour
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
    public Character_Data character_Data;
    private float time;

    // 스킬 확인
    public bool isSkillUse;
    [SerializeField] private KeyCode SkillUse = KeyCode.F;

    private void Awake()
    {
        // 스킬이 패시브일때 스킬사용 중
        if (character_Data.isSkillPassive)
        {
            isSkillUse = true;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (character_Data.isSkillPassive)
        {// 스킬이 패시브이면 스킬이 꺼져있을 경우 시간 지남에 따라 스킬 재가동

            //TODO: 스킬이 패시브일 경우 게이지 채워지는 경우 확인 필요함(패시브가 시간에 따라인지 확인해야함)
            if (!isSkillUse && time>=5)
            {
                isSkillUse = true;
                time = 0f;
            }
        }
        else
        {
            if (character_Data.isDefence)
            {
                // 
            }
            else
            {
                //TODO: 그 장애물 삭제하는 능력 넣어야함
            }
        }
    }

    private void Skill_Input()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isSkillUse = true;
        }
    }
    

}
