using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody playerRigid;
    private Vector3 targetPosition;
    private float moveSpeed = 10f;
    private bool isMove = false;

    private void Awake() {
        Debug.Log($"Rigid Component : {TryGetComponent(out playerRigid)}");
        targetPosition = playerRigid.position;
    }

    private void Update() {
        MovePlayer();
        //Debug.Log($"Target : {targetPosition}");
    }

    private void LateUpdate() {
    }
    public void MovePlayer() {
        float direction = -1f;

        // 키 입력 유효성
        if (Input.anyKeyDown) {
            isMove = true;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                direction = 0f;
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                direction = -90f;
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                direction = 180f;
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                direction = 90f;

            // WASD 로 direction이 바뀐 경우만 이동
            if (direction != -1) {  
                transform.rotation = Quaternion.Euler(0, direction, 0);
                targetPosition = MapPosition.ForwardPosition(playerRigid.position, transform.forward);
                StopCoroutine(Move());
                StartCoroutine(Move());
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {

        //TODO: 충돌시 스프라이트 변경 또는 패배 이벤트 추가 바랍니다.

        if (collision.gameObject.CompareTag("Obs") ||
            collision.gameObject.CompareTag("DieObs") ||
            collision.gameObject.CompareTag("Wall")) {
            // Obs 장애물과 충돌 시 이동 종료
            Debug.Log("COLLIDED");
            playerRigid.velocity = Vector3.zero;
            targetPosition = MapPosition.ForwardPosition(playerRigid.position, -transform.forward);
            
            // isMove = false;
            // Obs 장애물 충돌시 이동 종료하면 pos 값이 2의 배수가 아니라 1.5 등 중간 실수에 멈추는 이슈
            // 해결 위해서 충돌시 targetPosition을 진행 방향의 이전 타일로 설정하도록 구현
        }
    }

    private IEnumerator Move() {
        // targetPosition 까지 부드럽게 이동
        // DO NOT MODIFY

        while (isMove) {
            playerRigid.MovePosition(playerRigid.position +
                (targetPosition - playerRigid.position) * Time.deltaTime * moveSpeed);
            if (transform.parent != null) transform.parent.position = playerRigid.position;

            yield return new WaitForFixedUpdate();
            if(playerRigid.position.Equals(targetPosition))
                isMove = false;
            // rigid Position 값이 targetPosition에 정확히 equal 되지 않는 이슈. (플레이에 지장없음)
        }
    }

    /*
     * 1. 방향키를 누르면
     * 2. 해당 방향을 보고
     * 3. 맵 좌표를 계산하고
     * 4. 코루틴으로 해당 좌표 이동시까지 rigid MovePosition
     * 5. 이동 중에는 bool Flag true 로 하고
     * 6. 이동이 끝날때는 Flag false (이슈 있음)
     * 7. 중간에 CollideEnter 할 경우에도 Flag false
     * 
     */

}
