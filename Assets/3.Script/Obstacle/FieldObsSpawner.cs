using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObsSpawner : ObsSpawner
{
    [SerializeField]
    private float range = 30f;              //���� ���� �ݰ� ����

    private void Awake()
    {
        initObsticle();
    }

    private void Update()
    {
        //TODO: player �̵��ϸ� ���� �߰�

        deadCheck();
    }
}
