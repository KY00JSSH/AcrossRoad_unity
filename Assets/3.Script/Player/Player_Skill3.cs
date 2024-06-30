using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill3 : MonoBehaviour
{
    /*
     * player �ݰ� 50f�� ��ü activeFalse
     */

    private List<GameObject> activeObss;    //���� active���� obss

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
    private void Init() //�⺻ ���� �ʱ�ȭ
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
                //TODO: ���� �� ������ ����!!
                Debug.Log("Player_Skill3 ���� ���� �����Ǿ����� ��� ����ƮȮ�� " + rock.name); 
            }
        }

        foreach (GameObject rock in activeObss)
        {
            if (Vector3.Distance(rock.transform.position, playerPos) <= 50f)  // player ���� position range ���� �ȿ�
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
            if (Vector3.Distance(car.transform.position, playerPos) <= 50f)  // player ���� position range ���� �ȿ�
            {
                car.SetActive(false);
            }
        }

        rocksSpawner.DropRocksAroundPlayer();

        List<Vector3> carPositions = MapControl.GetAllCarSpawnPosition();
        horizObsSpawner.SpawnCars(carPositions);
    }
}
