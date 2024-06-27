using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Character_Data", fileName = "Character_Data")]
public class Character_Data : ScriptableObject
{
    /*
    캐릭터 특성 추가
    외부 인스펙터 창에서 캐릭터의 특성을 지정할 수 있는 스크립트

    2. 스킬사용 -> 패시브 / 엑티브 => bool
         스킬 사용 키보드 F => input.getkey.f
            1. 스킬 방어막 bool -> 활성화가 되어있는 상태 tag의 적을 만나면 1회 죽음 면제
            2. 스킬 무적 5초 게이지 + 키보드
            3. 스킬 : 현재 장애 요소 삭제 => 전홍현 팀장
    3. 게이지 -> UI 당겨오기 -> 스크립트를 만들기
    4. 

     */


    public bool isSkillPassive;
    public bool isDefence;
    public bool isDelete;



    // awake에서 스킬이 패시브인지 확인 후 메소드 끌어오기



}
