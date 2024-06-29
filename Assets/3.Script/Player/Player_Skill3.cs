using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill3 : MonoBehaviour
{
    /*
     * player 반경 30f의 물체 activeFalse
     */

    private List<GameObject> activeObss;    //현재 active중인 obss

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

        //active인 obss들 중에서 현재 position 의 반경에 있는 object false
        //false되면 다음 obss들 새로운 위치에서 true

        foreach (GameObject rock in rocksSpawner.obsList)
        {
            if (rock.activeInHierarchy)
            {
                activeObss.Add(rock);
            }
        }

        foreach (GameObject rock in activeObss)
        {
            if (Vector3.Distance(rock.transform.position, playerPos) <= 50f)  // player 현재 position range 범위 안에
            {
                Debug.Log("remove");
                rock.SetActive(false);
            }
        }

        //TODO: DROP 딜레이 주기
        //TODO: SKILL Effect
        //rocksSpawner.DropRocksAroundPlayer(playerPos);           
    }
}
