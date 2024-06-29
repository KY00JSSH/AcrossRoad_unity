using UnityEngine;

public class MapTileControl : MonoBehaviour {
    private Transform playerTransform;
    public int direction { get; private set; }

    private void OnEnable() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        direction = Random.Range(0, 2);
    }

    private void Update() {
        if (playerTransform.position.z - transform.position.z > 10)
            gameObject.SetActive(false);
    }
}
