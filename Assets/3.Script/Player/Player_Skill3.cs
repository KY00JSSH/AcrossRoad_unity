using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill3 : MonoBehaviour
{
    /*
     * player 반경 50f의 물체 activeFalse
     */

    private List<GameObject> activeObss;    //현재 active중인 obss

    private RocksSpawner rocksSpawner;
    private HorizObsSpawner horizObsSpawner;

    private PlayerControll playerControll;
    public ExplosionEffect explosionEffect;

    private void Awake()
    {
        GameObject.FindObjectOfType<RocksSpawner>().TryGetComponent(out rocksSpawner);
        GameObject.FindObjectOfType<HorizObsSpawner>().TryGetComponent(out horizObsSpawner);

        playerControll = GetComponent<PlayerControll>();
        activeObss = new List<GameObject>();
    }

    private void Update()
    {
        if (playerControll.isSkillUse)
        {
            if (explosionEffect != null)
            {
                explosionEffect.SetPositionOfEffect();
            }
            RemoveObss();
        }
        
    }

    /*
    private void Init() //기본 세팅 초기화
    {
        isSkillUse = false;
    }
    */
    private void RemoveObss()
    {
        Vector3 playerPos = gameObject.transform.position;

        foreach (GameObject rock in rocksSpawner.obsList)
        {
            if (rock.activeInHierarchy)
            {
                activeObss.Add(rock);
                //TODO: 여기 돌 생성이 많음!!
                Debug.Log("Player_Skill3 내부 돌이 생성되어있을 경우 리스트확인 " + rock.name); 
            }
        }

        foreach (GameObject rock in activeObss)
        {
            if (Vector3.Distance(rock.transform.position, playerPos) <= 50f)  // player 현재 position range 범위 안에
            {
                rock.SetActive(false);
            }
        }

        activeObss.Clear();

        foreach (GameObject car in horizObsSpawner.obsList)
        {
            if (car.activeInHierarchy)
            {
                activeObss.Add(car);
            }
        }

        foreach (GameObject car in activeObss)
        {
            if (Vector3.Distance(car.transform.position, playerPos) <= 50f)  // player 현재 position range 범위 안에
            {
                car.SetActive(false);
            }
        }

        rocksSpawner.DropRocksAroundPlayer();

        List<Vector3> carPositions = MapControl.GetAllCarSpawnPosition();
        horizObsSpawner.SpawnCars(carPositions);
    }
}
