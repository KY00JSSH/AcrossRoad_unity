using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{

    public ParticleSystem dieParticle;
    private PlayerControll playerControll;
    private void Start()
    {
        dieParticle.transform.position = transform.position;

        playerControll = GetComponentInChildren<PlayerControll>();
        if (playerControll != null)
        {
            Debug.Log("playerControll null 아님");
            playerControll.OnDead += Player_Die_Check;

        }
        else
        {
            Debug.Log("playerControll null");

        }

    }

    public void Player_Die_Check()
    {
        Debug.Log("캐릭터 죽은 후 호출");
        StartCoroutine(DieParticle());
    }


    public IEnumerator DieParticle()
    {
        Debug.Log("들어오나?");
        dieParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("안들어오나?");
        dieParticle.gameObject.SetActive(false);
    }
}
