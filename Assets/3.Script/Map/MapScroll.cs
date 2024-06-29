using System.Collections.Generic;
using UnityEngine;

public enum Tile {
    Park,
    Road
}

public class MapScroll : MonoBehaviour {
    [SerializeField] private GameObject[] TilePrefebs;
    private List<GameObject> CreatedTiles = new List<GameObject>();
    private GameObject RecentCreatedTile;
    private Transform playerTransform;
    private int CreatedCount = 0;

    private int minCreateLength = 1, maxCreateLength = 6;
    [SerializeField] private int visibleTileCount = 35;

    private void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start() {
        // ���� ���� ���� �ʱ�ȭ
        for(int i = 0; i < 4; i++) 
            CreateTile(TilePrefebs[(int)Tile.Park], Vector3.back * 2 * i);
        CreatedCount -= 3;
        for (int i = 1; i < 4; i++)
            CreateTile(TilePrefebs[(int)Tile.Park], Vector3.forward * 2 * i);
    }

    private void Update() {
        // ������ Ÿ�� ����(������ Ÿ�� ��ġ) - �÷��̾� �Ÿ�(���� Ÿ�� ��ġ) = �տ� �� �� Ÿ���� �� �ִ���
        // ���� Ÿ�� ���� < ȭ�鿡 ���̴� Ÿ�� ���� = ���� ����
        int CurrentCount = Mathf.RoundToInt(playerTransform.position.z / 2f);
        if (CreatedCount - CurrentCount < visibleTileCount) CreateRandomTile();
    }

    public void CreateRandomTile() {
        // ������ ���̸�ŭ ������ Ÿ���� �����մϴ�.

        // ������ ������ Ÿ�ϰ� �ٸ� Ÿ�Ϸ� �����մϴ�.
        GameObject randomTile;
        do {
            randomTile = RandomTile();
        } while (randomTile.Equals(RecentCreatedTile));
        RecentCreatedTile = randomTile;
        int randomLength = Random.Range(minCreateLength, maxCreateLength);

        for (int i = 0; i < randomLength; i++) 
            CreateTile(randomTile, Vector3.forward * CreatedCount * 2);
    }

    public GameObject RandomTile() {
        // TilePrefebs[] ���� ���� Ÿ���� return �մϴ�.
        return TilePrefebs[Random.Range(0, TilePrefebs.Length)];
    }

    public void CreateTile(GameObject tile, Vector3 position) {
        // CreateTiles�� ��ϵ� Ÿ�� �� ��Ȱ��ȭ Ÿ���� ���� ���ϴ�.
        CreatedCount++;

        foreach(GameObject each in CreatedTiles) {
            if (each.layer.Equals(tile.layer)) {
                if(!each.activeSelf) {
                    each.transform.position = position;
                    each.SetActive(true);
                    return; // Ȱ��ȭ�� �޼��� ����
                }
            }
        }

        // ��Ȱ��ȭ�� Ÿ���� ������ ���� ���� ���ϴ�.
        GameObject newTile = Instantiate(tile, position, Quaternion.identity);
        newTile.transform.parent = transform;
        CreatedTiles.Add(newTile);
    }
}
