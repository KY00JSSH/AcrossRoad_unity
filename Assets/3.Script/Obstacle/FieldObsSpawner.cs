using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObsSpawner : ObsSpawner
{
    [SerializeField]
    private float range = 30f;              //랜덤 생성 반경 설정

    private void Awake()
    {
        initObsticle();
    }

    private void Update()
    {
        //TODO: player 이동하면 생성 추가

        deadCheck();
    }
}
