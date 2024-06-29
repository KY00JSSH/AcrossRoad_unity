using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : ObsSpawner
{
    private GameObject player;              //���� player

    [SerializeField]
    private float range = 10f;              //���� drop �ݰ� ����
    private Vector3 lastPlayerPosition;
    private float dropChangeDistance = 10f;  //player �̵��� ���� ������ �Ÿ� ����

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initObsticle();
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
        //TODO: player �̵��ϸ� DROP ���� �߰��ϱ�
        deadCheck();

        // Player�� ���� �Ÿ� �̻� �̵��ߴ��� Ȯ��
        if (Time.frameCount % 3 == 0)  //3�ʸ��� Ȯ��
        {
            //�̵��� �Ÿ��� �����Ÿ� �̻��϶� ��ġ �����ؼ� ����  drop
            if (Vector3.Distance(player.transform.position, lastPlayerPosition) >= dropChangeDistance)
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
            GameObject rock = obsList[Random.Range(0, obsList.Count)];
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

        List<GameObject> inactiveRocks = obsList.FindAll(rock => !rock.activeInHierarchy);
        if (inactiveRocks.Count > 0)
        {
            GameObject randomRock = inactiveRocks[Random.Range(0, inactiveRocks.Count)];
            randomRock.transform.position = GetRandomPosition(player.transform.position);
            randomRock.SetActive(true);
        }
    }
}