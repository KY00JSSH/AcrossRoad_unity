using UnityEngine;

public class MapTileControl : MonoBehaviour {
    private Transform playerTransform;

    private void OnEnable() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if (playerTransform.position.z - transform.position.z > 10)
            gameObject.SetActive(false);
    }
}
