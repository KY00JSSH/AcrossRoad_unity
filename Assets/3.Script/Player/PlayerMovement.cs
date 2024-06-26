using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody playerRigid;
    private Animator player_ani;
    private Vector3 targetPosition;
    private float moveSpeed = 10f;
    private bool isMove = false;

    private int LeftLimit, RightLimit, BackLimit;
    public int score;

    private bool canMove = true; // HowToPlay, Ranking 나타났을 때 플레이어가 못움직이게 하기 위함 => 240630 11:14 지훈 수정

    private AudioManager audioManager;

    private void Awake() {
        Debug.Log($"Rigid Component : {TryGetComponent(out playerRigid)}");
        player_ani = GetComponent<Animator>();
        targetPosition = playerRigid.position;
        score = 0;
        audioManager = GetComponent<AudioManager>();
    }

    private void Start() {
        LeftLimit = -24;
        RightLimit = 24;    // tile X scale
        BackLimit = -4;
    }

    private void Update() {
        //MovePlayer(); => 240630 11:14 지훈 수정
        //Debug.Log($"Target : {targetPosition}");

        if(canMove) // => 240630 11:14 지훈 수정
        {
            MovePlayer();
        }
        score = Mathf.Max(Mathf.RoundToInt(transform.position.z) / 2 , score);
        BackLimit = Mathf.Max(score * 2 - 10, -4);
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
                player_ani.SetTrigger("IsJump");
                targetPosition = MapPosition.ForwardPosition(playerRigid.position, transform.forward);

                targetPosition.x = Mathf.Clamp(targetPosition.x, LeftLimit, RightLimit);
                targetPosition.z = Mathf.Clamp(targetPosition.z, BackLimit, targetPosition.z);

                StopCoroutine(Move());
                StartCoroutine(Move());
                audioManager.PlayMoveSound();
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

    public void SetMovementEnabled(bool enabled) //=> 240630 11:14 지훈 수정
    {
        canMove = enabled;
        if (!enabled)
        {
            isMove = false;
            playerRigid.velocity = Vector3.zero;
            StopAllCoroutines();
        }
    }
}
