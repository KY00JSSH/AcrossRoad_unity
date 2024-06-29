using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizObsController : MonoBehaviour
{
    HorizObsSpawner horizSp;
    private float moveSpeed = 1.0f;

    private void Awake()
    {
        GameObject.FindObjectOfType<HorizObsSpawner>().TryGetComponent(out horizSp);
    }

    private void setRandomSpeed()
    {
        moveSpeed = Random.Range(1.0f, 5.0f);
    }

    private void ObsMove()
    {
        if (gameObject.transform.position.x <= horizSp.leftPoint.x)
        {
            gameObject.transform.position += Vector3.right* moveSpeed * Time.deltaTime;
        }
        else if(gameObject.transform.position.x >= horizSp.rightPoint.x)
        {
            gameObject.transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
