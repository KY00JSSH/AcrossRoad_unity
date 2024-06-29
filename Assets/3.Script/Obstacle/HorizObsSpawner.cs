using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizObsSpawner : ObsSpawner
{
    private GameObject player;              //현재 player
    [SerializeField]
    private float range = 30f;              //랜덤 생성 반경 설정

    public Vector3 leftPoint;              //왼쪽 좌표 기준
    public Vector3 rightPoint;             //오른쪽 좌표 기준

    bool[] rightDir;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initObsticle();
    }

    private void Update()
    {
        //TODO: player 이동하면 생성 추가

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
        //처음 세팅하면 안바뀌니까 setActive(false)한 애들은 또 다시 세팅해줘야함
        
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
