using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{

    public ParticleSystem dieParticle;
    private PlayerControll playerControll;
    [SerializeField] GameObject activeObj;


    private void Start()
    {

        playerControll = GetComponentInChildren<PlayerControll>();
        if (playerControll != null)
        {
            // 플레이어가 죽으면 활성화 되어있는 오브젝트를 찾아 위치 동기화
            playerControll.OnDead += Find_Active_Object;
            // 플레이어가 죽으면 파티클 활성화하는 코루틴 실행
            playerControll.OnDead += Player_Die_Check;
        }
        else
        {
            Debug.Log("playerControll null");
        }

    }

    
    public void Find_Active_Object()
    {
        // 상위 오브젝트에서 활성화되어있는 오브젝트를 찾음
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf && child.gameObject.CompareTag("Player"))
            {
                dieParticle.transform.position = child.transform.position;
            }
        }
    }

    public void Player_Die_Check()
    {
        StartCoroutine(DieParticle());
    }


    public IEnumerator DieParticle()
    {
        dieParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        dieParticle.gameObject.SetActive(false);
    }
}
