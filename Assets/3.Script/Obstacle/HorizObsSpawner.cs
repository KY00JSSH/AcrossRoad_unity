using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizObsSpawner : ObsSpawner
{
    private GameObject player;              //���� player
    [SerializeField]
    private float range = 30f;              //���� ���� �ݰ� ����

    public Vector3 leftPoint;              //���� ��ǥ ����
    public Vector3 rightPoint;             //������ ��ǥ ����

    bool[] rightDir;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initObsticle();
    }

    private void Update()
    {
        //TODO: player �̵��ϸ� ���� �߰�

        deadCheck();
    }

    private void RandomSettDirection()
    {
        int count = obsList.Count;
        rightDir = new bool[count];
        for (int i = 0; i < count; i++)
        {
            rightDir[i] = Random.Range(0, 2) == 0 ? false : true;
        }
    }

    private void SettNewDir()
    {
        //ó�� �����ϸ� �ȹٲ�ϱ� setActive(false)�� �ֵ��� �� �ٽ� �����������
        
    }

    public void CreateAroundPlayer()
    {
        for (int i = 0; i < 16; i++)
        {
            int carNum = Random.Range(0, obsList.Count);
            GameObject car = obsList[carNum];
            Vector3 randomPosition = GetRandomPosition(carNum, player.transform.position);
            car.transform.position = randomPosition;
            car.SetActive(true);
        }
    }

    private Vector3 GetRandomPosition(int carNum, Vector3 playerPosition)
    {
        if()
        Vector3 randPos;
        return randPos;
    }

}
