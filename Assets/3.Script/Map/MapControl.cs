using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor;
using UnityEngine;

public enum Tile {
    Park,
    Road
}

public class MapControl : MonoBehaviour {
    [SerializeField] private GameObject[] TilePrefebs;
    private List<GameObject> CreatedTiles = new List<GameObject>();
    private GameObject RecentCreatedTile;
    private Transform playerTransform;
    private int CreatedCount = 0;

    private int minCreateLength = 1, maxCreateLength = 6;
    [SerializeField] private int visibleTileCount = 35;
    private MapObstacleSpawn obstacleSpawn;

    public static List<Vector3> GetAllCarSpawnPosition() {
        // �� �� �����ϴ� ��� ���� Ÿ���� �ڵ��� ���� ��ġ�� ���մϴ�.
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        List<GameObject> CreatedTiles = FindObjectOfType<MapControl>().CreatedTiles;
        List<Vector3> positions = new List<Vector3>();
        int tileDistance = 36;

        foreach (GameObject each in CreatedTiles) {
            if (each.layer.Equals(26) &&        // tileRoad layerIndex = 26
                Mathf.Abs(each.transform.position.z - playerTransform.position.z) < tileDistance) {    
                int direction = each.GetComponent<MapTileControl>().direction * 2 - 1;
                Vector3 spawnPos = new Vector3(
                    (each.transform.localScale.x - 1) * direction,
                    each.transform.position.y, each.transform.position.z);
                positions.Add(spawnPos);
            }
        }
        return positions;
    }

    private void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        TryGetComponent(out obstacleSpawn);
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
        GetAllCarSpawnPosition();
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

        if(tile.layer.Equals(25))  // tileRoad layerIndex = 25
            obstacleSpawn.Spawn(position);

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
