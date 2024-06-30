using System.Collections.Generic;
using UnityEngine;

public class MapObstacleSpawn : MonoBehaviour {
    [SerializeField] private GameObject[] ObstaclePrefebs;
    private List<GameObject> CreatedObstacles = new List<GameObject>();

    public void Spawn(Vector3 position) {
        int minPosX = -26, maxPosX = 26;    // tile transform X Scale.
        int randomObsCount = Random.Range(0, 4);

        float lastPosX = minPosX;
        for(int i = 0;  i< randomObsCount; i++) {
            float randomPosX = Random.Range(6, 12) / 2 * 2;
            position.x = lastPosX + randomPosX;
            if (position.x.Equals(4) && position.z.Equals(0)) position.x += 2;
            CreateObstacle(RandomObs(), position);
            if(Random.Range(0, 5) == 0) {
                position.x += 2;
                if (position.x.Equals(4) && position.z.Equals(0)) position.x += 2;
                CreateObstacle(RandomObs(), position);
            }
            lastPosX = position.x;
        }

        lastPosX = maxPosX;
        for (int i = 0; i < randomObsCount; i++) {
            float randomPosX = Random.Range(4, 12) / 2 * 2;
            position.x = lastPosX - randomPosX;
            if (position.x.Equals(4) && position.z.Equals(0)) position.x -= 2;
            CreateObstacle(RandomObs(), position);
            if (Random.Range(0, 5) == 0) {
                position.x -= 2;
                if (position.x.Equals(4) && position.z.Equals(0)) position.x -= 2;
                CreateObstacle(RandomObs(), position);
            }
            lastPosX = position.x;
        }
    }

    public GameObject RandomObs() {
        return ObstaclePrefebs[Random.Range(0, ObstaclePrefebs.Length)];
    }

    public void CreateObstacle(GameObject obs, Vector3 position) {
        foreach (GameObject each in CreatedObstacles) {
            if (each.layer.Equals(obs.layer)) {
                if (!each.activeSelf) {
                    each.transform.position = position;
                    each.SetActive(true);
                    return;
                }
            }
        }

        GameObject newObs = Instantiate(obs, position, Quaternion.identity);
        newObs.transform.parent = transform;
        CreatedObstacles.Add(newObs);
    }
}
