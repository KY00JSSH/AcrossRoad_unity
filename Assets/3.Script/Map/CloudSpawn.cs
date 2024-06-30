using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {
    [SerializeField] private GameObject cloudPrefeb;
    private GameObject[] cloudList;
    private Transform cameraTransform;
    
    private int cloudCount = 15;
    private float spawnedTime, spawnRate;

    private void Awake() {
        cameraTransform = FindObjectOfType<PlayerCamera>().transform;
    }

    private void Start() {
        cloudList = new GameObject[cloudCount];
        for (int i = 0; i < cloudCount; i++) {
            cloudList[i] = Instantiate(cloudPrefeb);
            cloudList[i].SetActive(false);
        }
        spawnedTime = Time.time;
        spawnRate = 0f;
    }

    private void Update() {
        if (Time.time > spawnedTime + spawnRate) {
            spawnedTime = Time.time;
            spawnRate = Random.Range(1f, 8f);

            foreach (GameObject eachCloud in cloudList) {
                if (!eachCloud.activeSelf) {
                    Vector3 spawnPosition =
                        new Vector3(30f, (Random.Range(0, 2) * 2 - 1) * Random.Range(10f, 20f),
                        cameraTransform.position.z + 8f + Random.Range(2f, 40f));
                    eachCloud.transform.position = spawnPosition;
                    eachCloud.SetActive(true);
                    break;
                }
            }
        }
    }
}