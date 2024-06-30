using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Skill1 : MonoBehaviour
{
    [SerializeField] private PlayerControll playerControll;
    public GameObject skillEffect;

    private void Awake()
    {
        playerControll = GetComponent<PlayerControll>();
    }
    private void Update()
    {
        skillEffect.transform.position = transform.position;
        if (playerControll.isSkillUse)
        {
            Debug.Log("활성화 확인 :  Player_Skill1" + playerControll.isSkillUse);
            skillEffect.SetActive(true);
        }
        else
        {
            skillEffect.SetActive(false);
        }
    }

}
