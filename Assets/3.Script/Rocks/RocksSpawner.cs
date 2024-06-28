using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;             //�⺻ rocks prefabs
    public List<GameObject> rocksList;     //pooling list

    private GameObject player;              //���� player
    public float range = 30f;              //���� drop �ݰ� ����
    public bool isDrop = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rocksList = new List<GameObject>();
        isDrop = false;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                GameObject rock = Instantiate(rocks[i]); //5�� prefabs 5���� list�� ����
                rock.SetActive(false);
                rocksList.Add(rock);
            }
        }
    }

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        DropRocksAroundPlayer(playerPosition);
    }

    public void DropRocksAroundPlayer(Vector3 playerPosition)
    {
        if (Vector3.Distance(transform.position, playerPosition) <= range)  // player ���� position range ���� �ȿ�
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject rock = rocksList[Random.Range(0, rocksList.Count)];
                Vector3 randomPosition = GetRandomPosition(playerPosition);
                rock.transform.position = randomPosition;
                rock.SetActive(true);
            }
        }
    }

    private Vector3 GetRandomPosition(Vector3 playerPosition)
    {
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        float randomY = Random.Range(playerPosition.y + 10f, playerPosition.y + 50f);

        return new Vector3(playerPosition.x + randomX, randomY, playerPosition.z + randomZ);
    }

    public void ActivateRandomNewRock()
    {
        List<GameObject> inactiveRocks = rocksList.FindAll(rock => !rock.activeInHierarchy);
        if (inactiveRocks.Count > 0)
        {
            GameObject randomRock = inactiveRocks[Random.Range(0, inactiveRocks.Count)];
            randomRock.transform.position = GetRandomPosition(player.transform.position);
            randomRock.SetActive(true);
        }
    }
}
