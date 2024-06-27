using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{

    /*
     *     1. 생존여부=> bool
    캐릭터 데이터에서 작성한 정보를 받아와서 오브젝트에 붙여서 실행할 스크립트    
        //TODO: 재시도에서 활성화가 되는지 초기화가 되는지 확인해야함
        //TODO: 전체 애니메이션 안붙였음
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
    //스킬사용 여부 확인

    public void Die()
    {
        if (OnDead != null)
        {
            OnDead();
        }
        //TODO: coll.transform.tag == "DieObs" 일 경우 비활성화 확인 => 다음 씬으로 넘어가야함
        transform.gameObject.SetActive(false);
        isDead = true;
    }

    private void Check_Skill()
    {
        // 스킬 사용 여부 확인하는 메소드
        Debug.Log("Check_Skill 내부"+ character_Skill.isSkillUse);
        // 패시브
        if (character_Skill.isSkillUse)
        {
            //TODO: 지나감 + 스킬 없어지는 애니메이션
            if (character_Skill.character_Data.isSkillPassive)
            {
                character_Skill.isSkillUse = false;
            }
            return;
        }
        else
        {
            //TODO: 캐릭터 죽는 애니메이션
            Die();
        }
    }

    // 장애물 tag통해서 캐릭터가 데미지를 받을지 안 받을지 결정
    private void OnCollisionEnter(Collision coll)
    {
        //TODO: tag로 확인 가능하나 물체를 위아래 통하여 뚫고 움직임 수정필요함
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
