using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{

    /*
     *     1. 생존여부=> bool
    캐릭터 데이터에서 작성한 정보를 받아와서 오브젝트에 붙여서 실행할 스크립트
    이동 키보드 방향키

     */

    public Character_Skill character_Skill;


    public bool isDead { get; protected set; }
    private bool isDamaged=false;

    public event Action OnDead;

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
        isDead = true;
    }

    //TODO: 안 받을 경우 스킬 여부 말지 결정하는 메소드 작성
    private void Check_Skill()
    {
        // 패시브
        if (character_Skill.isSkillUse)
        {
            character_Skill.isSkillUse = false;
            //TODO: 지나감 + 스킬 없어지는 애니메이션
        }
        else
        {
            Die();
            //TODO: 캐릭터 죽는 애니메이션
        }
    }


    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "")
        {
            //TODO: tag가 데미지를 안받는 물체 일 경우 tag 변경

        }
        else if (coll.transform.tag == "")
        {
            //TODO: tag가 데미지를 받는 물체 일 경우 tag 변경 + 스킬 여부 확인
            Check_Skill();
        }
    }
}
