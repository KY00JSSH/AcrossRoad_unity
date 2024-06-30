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

    private void Awake() {
        Debug.Log($"Rigid Component : {TryGetComponent(out playerRigid)}");
        player_ani = GetComponent<Animator>();
        targetPosition = playerRigid.position;
        score = 0;
    }

    private void Start() {
        LeftLimit = -24;
        RightLimit = 24;    // tile X scale
        BackLimit = -4;
    }

    private void Update() {
        MovePlayer();
        //Debug.Log($"Target : {targetPosition}");
        score = Mathf.Max(Mathf.RoundToInt(transform.position.z) / 2 , score);
        BackLimit = Mathf.Max(score * 2 - 10, -4);
    }


    public void MovePlayer() {
        float direction = -1f;

        // Ű �Է� ��ȿ��
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

            // WASD �� direction�� �ٲ� ��츸 �̵�
            if (direction != -1) {  
                transform.rotation = Quaternion.Euler(0, direction, 0);
                player_ani.SetTrigger("IsJump");
                targetPosition = MapPosition.ForwardPosition(playerRigid.position, transform.forward);

                targetPosition.x = Mathf.Clamp(targetPosition.x, LeftLimit, RightLimit);
                targetPosition.z = Mathf.Clamp(targetPosition.z, BackLimit, targetPosition.z);

                StopCoroutine(Move());
                StartCoroutine(Move());
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {

        //TODO: �浹�� ��������Ʈ ���� �Ǵ� �й� �̺�Ʈ �߰� �ٶ��ϴ�.

        if (collision.gameObject.CompareTag("Obs") ||
            collision.gameObject.CompareTag("DieObs") ||
            collision.gameObject.CompareTag("Wall")) {
            // Obs ��ֹ��� �浹 �� �̵� ����
            Debug.Log("COLLIDED");
            playerRigid.velocity = Vector3.zero;
            targetPosition = MapPosition.ForwardPosition(playerRigid.position, -transform.forward);
            
            // isMove = false;
            // Obs ��ֹ� �浹�� �̵� �����ϸ� pos ���� 2�� ����� �ƴ϶� 1.5 �� �߰� �Ǽ��� ���ߴ� �̽�
            // �ذ� ���ؼ� �浹�� targetPosition�� ���� ������ ���� Ÿ�Ϸ� �����ϵ��� ����
        }
    }

    private IEnumerator Move() {
        // targetPosition ���� �ε巴�� �̵�
        // DO NOT MODIFY

        while (isMove) {
            playerRigid.MovePosition(playerRigid.position +
                (targetPosition - playerRigid.position) * Time.deltaTime * moveSpeed);

            yield return new WaitForFixedUpdate();
            if(playerRigid.position.Equals(targetPosition))
                isMove = false;
            // rigid Position ���� targetPosition�� ��Ȯ�� equal ���� �ʴ� �̽�. (�÷��̿� �������)
        }
    }

    /*
     * 1. ����Ű�� ������
     * 2. �ش� ������ ����
     * 3. �� ��ǥ�� ����ϰ�
     * 4. �ڷ�ƾ���� �ش� ��ǥ �̵��ñ��� rigid MovePosition
     * 5. �̵� �߿��� bool Flag true �� �ϰ�
     * 6. �̵��� �������� Flag false (�̽� ����)
     * 7. �߰��� CollideEnter �� ��쿡�� Flag false
     * 
     */

}
