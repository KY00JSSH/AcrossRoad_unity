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
        // isMove flag ���� : ��ǥ ������ ������ ������ or Collide �浹�ϱ� �� ����
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
     * 1. ����Ű�� ������
     * 2. �ش� ������ ����
     * 3. �� ��ǥ�� ����ϰ�
     * 4. �ڷ�ƾ���� �ش� ��ǥ �̵��ñ��� rigid MovePosition
     * 5. �̵� �߿��� bool Flag true �� �ϰ�
     * 6. �̵��� �������� Flag false
     * 7. �߰��� CollideEnter �� ��쿡�� Flag false
     * 
     */

    private void OnCollisionEnter(Collision collision) {
        playerRigid.velocity = Vector3.zero;
        isMove = false;
    }
}
