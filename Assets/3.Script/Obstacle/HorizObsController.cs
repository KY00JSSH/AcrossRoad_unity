using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizObsController : MonoBehaviour
{
    private Vector3 direction;
    public Vector3 InitialPosition { get; private set; }

    private float xLimit = 24f; //x 최대 좌표
    private bool isDelayed = false;

    private float delayTime; // 새로운 딜레이 시간을 위한 변수

    private void Start()
    {
        StartCoroutine(InitialDelay());
    }

    public void SetDirection(Vector3 dir, float delay)
    {
        direction = dir;
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        InitialPosition = transform.position;

        //오른쪽으로 이동하는 차는 y 90으로 rotation, 왼쪽은 -90
        if (direction == Vector3.right)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (direction == Vector3.left)
        {
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }

        delayTime = delay; // 설정된 딜레이 시간 저장
    }

    public void Move(float distance)
    {
        if (isDelayed)
        {
            transform.Translate(Vector3.forward * distance);

            if (transform.position.x > xLimit)
            {
                transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xLimit)
            {
                transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
            }
        }
    }

    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelayed = true;
    }
}