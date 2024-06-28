using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;             //기본 rocks prefabs
    public List<GameObject> rocksList;     //pooling list

    private GameObject player;              //현재 player
    private PlayerControll playerCon;
    public float range = 30f;              //랜덤 drop 반경 설정
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
                GameObject rock = Instantiate(rocks[i]); //5개 prefabs 5개씩 list에 담음
                rock.SetActive(false);
                rocksList.Add(rock);
            }
        }
    }

    private void Start()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= range)  // player 현재 position range 범위 안에
        {
            lastPlayerPosition = player.transform.position; // 초기 Player 위치 저장
            DropRocksAroundPlayer(); // 처음 시작할 때 한번 Drop
        }
    }

    private void Update()
    {
        if (playerCon.isDead)
        {
            DeactivateAllRocks();
            return;
        }

        // Player가 일정 거리 이상 이동했는지 확인
        if (Time.frameCount % 6 == 0)
        {
            if (Vector3.Distance(player.transform.position, lastPlayerPosition) >= dropDistanceThreshold)
            {
                DropRocksAroundPlayer();
                lastPlayerPosition = player.transform.position; // 마지막 위치 갱신
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
        if (playerCon.isDead) return;  // Player와 충돌했으면 새로운 Rock 생성 방지

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