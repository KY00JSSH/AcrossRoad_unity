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
        // 맵 상 존재하는 모든 도로 타일의 자동차 생성 위치를 구합니다.
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
        // 게임 시작 발판 초기화
        for(int i = 0; i < 4; i++) 
            CreateTile(TilePrefebs[(int)Tile.Park], Vector3.back * 2 * i);
        CreatedCount -= 3;
        for (int i = 1; i < 4; i++)
            CreateTile(TilePrefebs[(int)Tile.Park], Vector3.forward * 2 * i);
    }

    private void Update() {
        // 생성된 타일 개수(마지막 타일 위치) - 플레이어 거리(현재 타일 위치) = 앞에 몇 개 타일이 더 있는지
        // 앞의 타일 개수 < 화면에 보이는 타일 개수 = 새로 생성
        int CurrentCount = Mathf.RoundToInt(playerTransform.position.z / 2f);
        if (CreatedCount - CurrentCount < visibleTileCount) CreateRandomTile();
        GetAllCarSpawnPosition();
    }

    public void CreateRandomTile() {
        // 랜덤한 길이만큼 랜덤한 타일을 생성합니다.

        // 이전에 생성한 타일과 다른 타일로 생성합니다.
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
        // TilePrefebs[] 에서 랜덤 타일을 return 합니다.
        return TilePrefebs[Random.Range(0, TilePrefebs.Length)];
    }

    public void CreateTile(GameObject tile, Vector3 position) {
        // CreateTiles에 등록된 타일 중 비활성화 타일을 꺼내 씁니다.
        CreatedCount++;

        if(tile.layer.Equals(25))  // tileRoad layerIndex = 25
            obstacleSpawn.Spawn(position);

        foreach(GameObject each in CreatedTiles) {
            if (each.layer.Equals(tile.layer)) {
                if(!each.activeSelf) {
                    each.transform.position = position;
                    each.SetActive(true);
                    return; // 활성화시 메서드 종료
                }
            }
        }

        // 비활성화된 타일이 없으면 새로 만들어서 씁니다.
        GameObject newTile = Instantiate(tile, position, Quaternion.identity);
        newTile.transform.parent = transform;
        CreatedTiles.Add(newTile);
    }
}
