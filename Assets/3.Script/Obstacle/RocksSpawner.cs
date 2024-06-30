using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : ObsSpawner
{
    private GameObject player;              //현재 player

    [SerializeField]
    private float range = 10f;              //랜덤 drop 반경 설정
    private Vector3 lastPlayerPosition;
    private float dropChangeDistance = 10f;  //player 이동시 새로 갱신할 거리 기준

    [SerializeField]
    private float fallSpeed = 10f;  // 떨어지는 속도 설정

    [SerializeField]
    private int maxActiveRocks = 25; // 최대 활성화된 돌의 수

    public Vector3 PlayerPosition
    {
        get { return player.transform.position; }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initObsticle();
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
        deadCheck();

        // Player가 일정 거리 이상 이동했는지 확인
        if (Time.frameCount % 3 == 0)  //3초마다 확인
        {
            //이동한 거리가 일정거리 이상일때 위치 갱신해서 새로  drop
            if (Vector3.Distance(player.transform.position, lastPlayerPosition) >= dropChangeDistance)
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
            GameObject rock = obsList[Random.Range(0, obsList.Count)];
            Vector3 randomPosition = GetRandomPosition(player.transform.position);
            rock.transform.position = randomPosition;
            rock.SetActive(true);
            rock.GetComponent<RocksController>().SetFallSpeed(fallSpeed); // 떨어지는 속도 설정
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

        if (CountActiveRocks() >= maxActiveRocks)
            return;

        List<GameObject> inactiveRocks = obsList.FindAll(rock => !rock.activeInHierarchy);
        if (inactiveRocks.Count > 0)
        {
            GameObject randomRock = inactiveRocks[Random.Range(0, inactiveRocks.Count)];
            randomRock.transform.position = GetRandomPosition(player.transform.position);
            randomRock.SetActive(true);
            randomRock.GetComponent<RocksController>().SetFallSpeed(fallSpeed); // 떨어지는 속도 설정
        }
    }

    private int CountActiveRocks()
    {
        int count = 0;
        foreach (GameObject rock in obsList)
        {
            if (rock.activeInHierarchy)
            {
                count++;
            }
        }
        return count;
    }
}