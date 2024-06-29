using System.Collections.Generic;
using UnityEngine;

public class MapObstacleSpawn : MonoBehaviour {
    [SerializeField] private GameObject[] ObstaclePrefebs;
    private List<GameObject> CreatedObstacles = new List<GameObject>();

    public void Spawn() {

    }

    public void CreateObstacle(GameObject tile, Vector3 position) {
        foreach(GameObject each in CreatedObstacles) {
            if (!each.activeSelf) {
                each.transform.position = position;

            }
        }
    }


    /*
    Vector3[] spawnPosition;
    public Vector3[] GetSpawnPosition() {

    }
    transform.position = GetCarSpawnPosition();

    public static Vector3 GetCarSpawnPosition();
    */
}
