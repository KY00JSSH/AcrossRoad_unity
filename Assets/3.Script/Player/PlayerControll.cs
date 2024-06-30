using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    /*
    캐릭터 데이터에서 작성한 정보를 받아와서 오브젝트에 붙여서 실행할 스크립트    

    1. tag로 장애물 데미지 여부 확인

    2. 스킬 패시브 액티브 확인
        2-1. 패시브 : 스킬 지속 활성화 => OnCollisionEnter에서 tag확인 후 스킬 off 
        2-2. 액티브 : 키보드 input 혹은 button.onclick확인 후 스킬 활성화 bool 

    3. gaugetime 관리
        - 초기 실행 : gaugetime 값을 10으로 설정하여 스킬 사용 가능 
        - update에서 스킬 사용 isSkillUse + gaugetime 5초 이상시 (gaugetime + isSkillUse) 초기화 

        //TODO: 스킬 bool 제어 하고 그 값을 넘기면 해당 스킬 스크립트에서 스킬 사용 + 이펙트 활성화
     */

    public bool isDead { get; protected set; }
    public event Action OnDead;

    // 버튼으로 스킬 사용
    public Button SkillButton;
    public Sprite ButtonSprite;

    // 스킬 사용해서 넘겨줘야하는 값
    public bool isSkillUse;
    public bool isSkillPassive;

    // 업데이트에서 게이지는 시간 추가 -> 스킬 사용 후 게이지값 초기화
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
            // 패시브일 경우 일단 계속 시간 확인해서 스킬 켜야함
            Skill_Passive_On();
            SkillButton.enabled = false; // 패시브인 경우 버튼 활성화가 되어있으나 사용 불가
        }
        else
        {//  패시브가 아닐경우 
            // 스킬 사용 변경 메소드
            Skill_Active_On();
            if (isSkillUse == false && gaugeTime >=10)
            {
                //게이지 시간이 찼을 경우 버튼 활성화 선택가능
                SkillButton.gameObject.SetActive(true);
                SkillButton.onClick.AddListener(Skill_Active_Button_Use_On);
            }
            // 초기화
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
        //스킬 사용과 사용 시간이 넘었으면 초기화
        if (isSkillUse && gaugeTime >= 2f)
        {
            gaugeTime = 0f;
            isSkillUse = false;
            SkillButton.gameObject.SetActive(false);
            Debug.Log("스킬 사용 / 게이지 시간 초기화 완료 위치");
        }
    }

    private void Skill_Active_On()
    {
        // 스킬 입력 받는 부분
        if (Input.GetKeyDown(KeyCode.R) && isSkillUse == false && gaugeTime >= 10f)
        {
            Debug.Log("스킬 사용");
            isSkillUse = true;
            gaugeTime = 0f;
            SkillButton.gameObject.SetActive(false); // 스킬 사용 후 버튼 비활성화
            // SkillButton.gameObject.SetActive(false); // 스킬 사용 후 버튼 비활성화
            audioManager.PlaySkillSound();
        }
    }

    private void Skill_Active_Button_Use_On()
    {
        Debug.Log("버튼으로 스킬 사용");
        isSkillUse = true;
        gaugeTime = 0f;
        SkillButton.gameObject.SetActive(false); // 스킬 사용 후 버튼 비활성화
        //SkillButton.gameObject.SetActive(false); // 스킬 사용 후 버튼 비활성화
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
                SkillButton.gameObject.SetActive(false); // 스킬1번 맞은 후 버튼 비활성화
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
