using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksController : MonoBehaviour
{
    private RocksSpawner spawner;

    private void Awake()
    {
        GameObject.FindObjectOfType<RocksSpawner>().TryGetComponent(out spawner);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
            spawner.ActivateRandomNewRock();
        }
    }
}
