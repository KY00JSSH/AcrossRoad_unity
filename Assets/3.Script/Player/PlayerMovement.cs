using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody playerRigid;
    private float moveDistance = 2f, moveSpeed = 5f;
    private bool isMove = false;
    private void Awake() {
        Debug.Log($"Rigid Component : {TryGetComponent(out playerRigid)}");
    }


    private void Update() {
        KeyCode InputKey = CheckInputMove();
        if (isMove) {
            Debug.Log("WOW");
            MovePlayer(InputKey);
        }
        // isMove flag 조건 : 목표 지점에 도달할 때까지 or Collide 충돌하기 전 까지
    }

    public void MovePlayer(KeyCode key) {
        float direction = 0f;
        switch (key) {
            case KeyCode.W: direction = 0f; break;
            case KeyCode.A: direction = -90f; break;
            case KeyCode.S: direction = 180f; break;
            case KeyCode.D: direction = 90f; break;
        }
        playerRigid.rotation = Quaternion.Euler(0, direction, 0);
        isMove = false;

    }

    public KeyCode CheckInputMove() {
        
        if (Input.anyKeyDown) {
            isMove = true;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
                return KeyCode.W;
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                return KeyCode.A;
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                return KeyCode.S;
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                return KeyCode.D;
        }
        isMove = false;
        return KeyCode.None;
    }


    /*
     * 1. 방향키를 누르면
     * 2. 해당 방향을 보고
     * 3. 맵 좌표를 계산하고
     * 4. 코루틴으로 해당 좌표 이동시까지 rigid MovePosition
     * 5. 이동 중에는 bool Flag true 로 하고
     * 6. 이동이 끝날때는 Flag false
     * 7. 중간에 CollideEnter 할 경우에도 Flag false
     * 
     */

    private void OnCollisionEnter(Collision collision) {
        playerRigid.velocity = Vector3.zero;
        isMove = false;
    }
}
