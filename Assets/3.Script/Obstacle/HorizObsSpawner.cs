using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizObsSpawner : ObsSpawner
{
    private GameObject player; // 현재 player
    [SerializeField]
    private int numberOfObstacles = 30; // 활성화할 장애물 수
    [SerializeField]
    private float movementSpeed = 10f; // 장애물 이동 속도
    private int maxCarNum = 3; // 각 z 위치에 최대 차 수
    private float backDistance = 4f; // 플레이어 위치에서 z축 뒤로 비활성화할 거리
    private float minSpacing = 8f; // 최소 간격

    private Vector3 prevPlayerPos;
    private float spawnThreshold = 1f; // 플레이어가 이동해야 하는 최소 거리

    private Dictionary<float, int> zPositionCarCount;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initObsticle();
        prevPlayerPos = player.transform.position;
        zPositionCarCount = new Dictionary<float, int>();
    }

    private void Update()
    {
        deadCheck();

        if (HasPlayerMoved())
        {
            List<Vector3> carPositions = MapControl.GetAllCarSpawnPosition();
            SpawnCars(carPositions);
            prevPlayerPos = player.transform.position;
        }

        MoveObstacles();
        RespawnObstacles();
    }

    private bool HasPlayerMoved()
    {
        return Vector3.Distance(player.transform.position, prevPlayerPos) >= spawnThreshold;
    }

    public void SpawnCars(List<Vector3> positions)
    {
        int obstaclesActivated = 0;

        foreach (Vector3 pos in positions)
        {
            if (obstaclesActivated >= numberOfObstacles)
                break;

            float zPos = pos.z;
            if (!zPositionCarCount.ContainsKey(zPos) || zPositionCarCount[zPos] < maxCarNum)
            {
                bool canSpawn = true;

                foreach (GameObject obst in obsList)
                {
                    if (
                        obst.activeInHierarchy && 
                        Mathf.Abs(obst.transform.position.x - pos.x) < minSpacing && 
                        obst.transform.position.z == zPos
                        )
                    {
                        canSpawn = false;
                        break;
                    }
                }

                if (canSpawn)
                {
                    foreach (GameObject obst in obsList)
                    {
                        if (!obst.activeInHierarchy)
                        {
                            obst.transform.position = pos;
                            obst.SetActive(true);

                            HorizObsController obsController = obst.GetComponent<HorizObsController>();
                            if (pos.x < player.transform.position.x)
                            {
                                obsController.SetDirection(Vector3.right);
                            }
                            else
                            {
                                obsController.SetDirection(Vector3.left);
                            }

                            if (!zPositionCarCount.ContainsKey(zPos))
                            {
                                zPositionCarCount[zPos] = 0;
                            }
                            zPositionCarCount[zPos]++;

                            obstaclesActivated++;
                            break;
                        }
                    }
                }
            }
        }
    }

    private void MoveObstacles()
    {
        foreach (GameObject obst in obsList)
        {
            if (obst.activeInHierarchy)
            {
                HorizObsController obsController = obst.GetComponent<HorizObsController>();
                obsController.Move(movementSpeed * Time.deltaTime);
            }
        }
    }

    private void RespawnObstacles()
    {
        foreach (GameObject obst in obsList)
        {
            if (obst.activeInHierarchy)
            {
                if (obst.transform.position.z < player.transform.position.z - backDistance)
                {
                    float initialZ = obst.transform.position.z;
                    obst.SetActive(false);

                    if (zPositionCarCount.ContainsKey(initialZ))
                    {
                        zPositionCarCount[initialZ]--;
                        if (zPositionCarCount[initialZ] <= 0)
                        {
                            zPositionCarCount.Remove(initialZ);
                        }
                    }
                    List<Vector3> carPositions = MapControl.GetAllCarSpawnPosition();
                    SpawnCars(carPositions);
                }
            }
        }
    }
}