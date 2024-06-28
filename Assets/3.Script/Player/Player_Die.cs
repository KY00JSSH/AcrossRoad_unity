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
            // �÷��̾ ������ Ȱ��ȭ �Ǿ��ִ� ������Ʈ�� ã�� ��ġ ����ȭ
            playerControll.OnDead += Find_Active_Object;
            // �÷��̾ ������ ��ƼŬ Ȱ��ȭ�ϴ� �ڷ�ƾ ����
            playerControll.OnDead += Player_Die_Check;
        }
        else
        {
            Debug.Log("playerControll null");
        }

    }

    
    public void Find_Active_Object()
    {
        // ���� ������Ʈ���� Ȱ��ȭ�Ǿ��ִ� ������Ʈ�� ã��
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
