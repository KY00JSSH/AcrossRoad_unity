using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksController : MonoBehaviour
{
    private RocksSpawner spawner;
    private Rigidbody rb;

    private void Awake()
    {
        GameObject.FindObjectOfType<RocksSpawner>().TryGetComponent(out spawner);
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // �⺻ �߷� ��� ����
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obs") || collision.gameObject.CompareTag("DieObs"))
        {
            gameObject.SetActive(false);
            spawner.ActivateRandomNewRock();
        }
    }

    private void Update()
    {
        // Ư�� y������ �������� �����
        if (transform.position.y < 0)
        {
            gameObject.SetActive(false);
            spawner.ActivateRandomNewRock();
        }
        // �÷��̾�� 4f �ڿ� �ִ� ��� ��Ȱ��ȭ
        if (spawner != null && transform.position.z < spawner.PlayerPosition.z - 4f)
        {
            gameObject.SetActive(false);
            spawner.ActivateRandomNewRock();
        }
    }

    public void SetFallSpeed(float fallSpeed)
    {
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -fallSpeed, 0); // �ӵ��� ���� ����
        }
    }
}
