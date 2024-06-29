using System.Collections.Generic;
using UnityEngine;

public class MapObstacleSpawn : MonoBehaviour {
    [SerializeField] private GameObject[] ObstaclePrefebs;
    private List<GameObject> CreatedObstacles = new List<GameObject>();

    public void Spawn() {

    }

    public void CreateObstacle(GameObject obs, Vector3 position) {
        foreach(GameObject each in CreatedObstacles) {
            if (each.layer.Equals(obs.layer)) {
                if (!each.activeSelf) {
                    each.transform.position = position;
                    each.SetActive(true);
                    return;
                }
            }
        }
    }
}
