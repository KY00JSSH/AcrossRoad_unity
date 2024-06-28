using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;             //�⺻ rocks prefabs

    private List<GameObject> rocksList;     //pooling list

    GameObject player;                      //���� player
    public float range = 100f;              //���� drop �ݰ� ����

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rocksList = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                GameObject rock= Instantiate(rocks[i]); //5�� prefabs 5���� list�� ����
                rock.SetActive(false);
                rocksList.Add(rock);
            }
        }
    }

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        if (Vector3.Distance(transform.position, playerPosition) <= range)  // player ���� position range ���� �ȿ�
        {
            //TODO: 100 ���� ���� RANGE�� ROCKS ����
        }
    }
}
