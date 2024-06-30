using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizObsSpawner : ObsSpawner
{
    private GameObject player; // ���� player
    [SerializeField]
    private int numberOfObstacles = 30; // Ȱ��ȭ�� ��ֹ� ��
    [SerializeField]
    private float movementSpeed = 10f; // ��ֹ� �̵� �ӵ�
    private int maxCarNum = 3; // �� z ��ġ�� �ִ� �� ��
    private float backDistance = 4f; // �÷��̾� ��ġ���� z�� �ڷ� ��Ȱ��ȭ�� �Ÿ�
    private float minSpacing = 6f; // �ּ� ����

    private Vector3 prevPlayerPos;
    private float spawnThreshold = 1f; // �÷��̾ �̵��ؾ� �ϴ� �ּ� �Ÿ�

    private Dictionary<float, int> zPositionCarCount;

    private void Awake()
    {
        setPlayerObject();
        initObsticle();
        prevPlayerPos = player.transform.position;
        zPositionCarCount = new Dictionary<float, int>();
    }
    public void setPlayerObject() {
        player = GameObject.FindGameObjectWithTag("Player");
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
                            bool positionOccupied = false;

                            foreach (GameObject otherObst in obsList)
                            {
                                if (otherObst.activeInHierarchy)
                                {
                                    float distance = Vector3.Distance(otherObst.transform.position, pos);
                                    if (distance < minSpacing)
                                    {
                                        positionOccupied = true;
                                        break;
                                    }
                                }
                            }

                            if (!positionOccupied)
                            {
                                obst.transform.position = pos;
                                obst.SetActive(true);

                                HorizObsController obsController = obst.GetComponent<HorizObsController>();
                                float delay = Random.Range(0.1f, 3f); // ��ֹ����� �ٸ� ������ ����
                                if (pos.x < player.transform.position.x)
                                {
                                    obsController.SetDirection(Vector3.right, delay);
                                }
                                else
                                {
                                    obsController.SetDirection(Vector3.left, delay);
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