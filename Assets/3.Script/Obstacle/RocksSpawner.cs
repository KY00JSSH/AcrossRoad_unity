using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;             //�⺻ rocks prefabs
    public List<GameObject> rocksList;     //pooling list

    private GameObject player;              //���� player
    private PlayerControll playerCon;
    public float range = 30f;              //���� drop �ݰ� ����
    public bool isDrop = false;

    private Vector3 lastPlayerPosition;

    public float dropDistanceThreshold = 10f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject.FindObjectOfType<PlayerControll>().TryGetComponent(out playerCon);

        rocksList = new List<GameObject>();
        isDrop = false;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject rock = Instantiate(rocks[i]); //5�� prefabs 5���� list�� ����
                rock.SetActive(false);
                rocksList.Add(rock);
            }
        }
    }

    private void Start()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= range)  // player ���� position range ���� �ȿ�
        {
            lastPlayerPosition = player.transform.position; // �ʱ� Player ��ġ ����
            DropRocksAroundPlayer(); // ó�� ������ �� �ѹ� Drop
        }
    }

    private void Update()
    {
        if (playerCon.isDead)
        {
            DeactivateAllRocks();
            return;
        }

        // Player�� ���� �Ÿ� �̻� �̵��ߴ��� Ȯ��
        if (Time.frameCount % 6 == 0)
        {
            if (Vector3.Distance(player.transform.position, lastPlayerPosition) >= dropDistanceThreshold)
            {
                DropRocksAroundPlayer();
                lastPlayerPosition = player.transform.position; // ������ ��ġ ����
            }
        }
    }

    public void DropRocksAroundPlayer()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject rock = rocksList[Random.Range(0, rocksList.Count)];
            Vector3 randomPosition = GetRandomPosition(player.transform.position);
            rock.transform.position = randomPosition;
            rock.SetActive(true);
        }
    }

    private Vector3 GetRandomPosition(Vector3 playerPosition)
    {
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        float randomY = Random.Range(playerPosition.y + 10f, playerPosition.y + 50f);

        Vector3 randPos = new Vector3(playerPosition.x + randomX, randomY, playerPosition.z + randomZ);
        Vector3 randPosToMap = MapPosition.ToMapCoord(randPos);

        return randPosToMap;
    }

    public void ActivateRandomNewRock()
    {
        if (playerCon.isDead) return;  // Player�� �浹������ ���ο� Rock ���� ����

        List<GameObject> inactiveRocks = rocksList.FindAll(rock => !rock.activeInHierarchy);
        if (inactiveRocks.Count > 0)
        {
            GameObject randomRock = inactiveRocks[Random.Range(0, inactiveRocks.Count)];
            randomRock.transform.position = GetRandomPosition(player.transform.position);
            randomRock.SetActive(true);
        }
    }

    public void DeactivateAllRocks()
    {
        foreach (GameObject rock in rocksList)
        {
            rock.SetActive(false);
        }
    }
}