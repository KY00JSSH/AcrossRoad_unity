using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour {
    private Transform playerTransform;
    private CinemachineVirtualCamera camera;

    private void Awake() {
        TryGetComponent(out camera);
    }

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        camera.Follow = playerTransform;
        camera.LookAt = playerTransform;
    }

}
