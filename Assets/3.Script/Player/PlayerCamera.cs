using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour {
    private Transform playerTransform;
    private CinemachineVirtualCamera virtualCamera;

    private void Awake() {
        TryGetComponent(out virtualCamera);
    }

    private void Start() {
        SetFollow();
    }

    public void SetFollow() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        virtualCamera.Follow = playerTransform;
        virtualCamera.LookAt = playerTransform;
    }
}
