using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill3 : MonoBehaviour
{
    /*
     * player �ݰ� 30f�� ��ü activeFalse
     */

    private List<GameObject> activeObss;    //���� active���� obss

    private RocksSpawner rocksSpawner;

    private PlayerControll playerControll;

    private void Awake()
    {
        GameObject.FindObjectOfType<RocksSpawner>().TryGetComponent(out rocksSpawner);
                
        playerControll = GetComponent<PlayerControll>();
        activeObss = new List<GameObject>();
    }


    private void Update()
    {

        playerControll.SkillStart += RemoveObss;
        playerControll.SkillStart -= RemoveObss;

        /*
         if (isSkillUse)
        {
            RemoveObss();
        }
         */

    }

    private void RemoveObss()
    {
        Vector3 playerPos = gameObject.transform.position;

        //active�� obss�� �߿��� ���� position �� �ݰ濡 �ִ� object false
        //false�Ǹ� ���� obss�� ���ο� ��ġ���� true

        foreach (GameObject rock in rocksSpawner.obsList)
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
        //TODO: SKILL Effect
        //rocksSpawner.DropRocksAroundPlayer(playerPos);           
    }
}
