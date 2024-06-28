using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;             //기본 rocks prefabs

    private List<GameObject> rocksList;     //pooling list

    GameObject player;                      //현재 player
    public float range = 100f;              //랜덤 drop 반경 설정

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rocksList = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                GameObject rock= Instantiate(rocks[i]); //5개 prefabs 5개씩 list에 담음
                rock.SetActive(false);
                rocksList.Add(rock);
            }
        }
    }

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        if (Vector3.Distance(transform.position, playerPosition) <= range)  // player 현재 position range 범위 안에
        {
            //TODO: 100 범위 랜덤 RANGE로 ROCKS 떨굼
        }
    }
}
