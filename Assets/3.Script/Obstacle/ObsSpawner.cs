using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obsPrefabs;
    public List<GameObject> obsList = new List<GameObject>();

    protected PlayerControll playerCon;       //playereController

    virtual protected void initObsticle()
    {
        GameObject.FindObjectOfType<PlayerControll>().TryGetComponent(out playerCon);

        for (int i = 0; i < obsPrefabs.Length; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                GameObject obst = Instantiate(obsPrefabs[i], transform);
                obst.SetActive(false);
                obsList.Add(obst);
            }
        }
    }

    protected void deadCheck()
    {
        if (playerCon.isDead)
        {
            DeactivateAllObst();
            return;
        }
    }

    public void DeactivateAllObst()
    {
        foreach (GameObject obst in obsList)
        {
            obst.SetActive(false);
        }
    }
}
