using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill3 : MonoBehaviour
{
    /*
     * player �ݰ� 30f�� ��ü activeFalse
     */

    [SerializeField]
    public bool isSkillUse = false;    //��ų ��뿩��

    private List<GameObject> activeObss;    //���� active���� obss

    private RocksSpawner rocksSpawner;

    private void Awake()
    {
        GameObject.FindObjectOfType<RocksSpawner>().TryGetComponent(out rocksSpawner);
        activeObss = new List<GameObject>();
        Init();
    }

    private void Update()
    {
        if (isSkillUse)
        {
            RemoveObss();
        }
    }

    private void Init() //�⺻ ���� �ʱ�ȭ
    {
        isSkillUse = false;
    }

    private void RemoveObss()
    {
        Vector3 playerPos = gameObject.transform.position;

        //active�� obss�� �߿��� ���� position �� �ݰ濡 �ִ� object false
        //false�Ǹ� ���� obss�� ���ο� ��ġ���� true

        foreach (GameObject rock in rocksSpawner.rocksList)
        {
            if (rock.activeInHierarchy)
            {
                activeObss.Add(rock);
            }
        }

        foreach (GameObject rock in activeObss)
        {
            if (Vector3.Distance(rock.transform.position, playerPos) <= 50f)  // player ���� position range ���� �ȿ�
            {
                Debug.Log("remove");
                rock.SetActive(false);
            }
        }

        //TODO: DROP ������ �ֱ�

        rocksSpawner.DropRocksAroundPlayer(playerPos);
        isSkillUse = false;
    }
}
