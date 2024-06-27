using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody playerRigid;
    private Vector3 targetPosition;
    private float moveDistance = 2f, moveSpeed = 15f;

    private void Awake() {
        TryGetComponent(out playerRigid);
    }

    private void Start() {
        targetPosition = transform.position;
    }
    private void Update() {
        
        // WASD or 방향키 입력에 따라 방향으로 이동
        // WASD 방향으로 쳐다보고(회전), 그 방향으로 moveDistance 만큼 이동

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            targetPosition = transform.position + transform.forward * moveDistance;
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            targetPosition = transform.position + transform.forward * moveDistance;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            targetPosition = transform.position + transform.forward * moveDistance;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            targetPosition = transform.position + transform.forward * moveDistance;
        }

        // targetPosition ( forward * moveDistace) 를 향해 moveSpeed 속도로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}