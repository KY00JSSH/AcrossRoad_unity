using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject explosionPrefabs;

    [SerializeField] private float explosionDelayTime = 0.01f;
    [SerializeField] private float effectLifetime = 0.5f;


    // Hierarchy 에 있는 활성화 되어있는 dieobs를 찾아와서 해당 위치 찾아옴
    private Vector3[] FindActiveDieObs()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        List<Vector3> activeVectors = new List<Vector3>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.activeInHierarchy && obj.CompareTag("DieObs"))
            {
                Debug.Log("현재 활성화 되어있는 DieObs" + obj.name);
                activeVectors.Add(obj.transform.position);
            }
        }
        return activeVectors.ToArray();
    }

    public void SetPositionOfEffect()
    {
        Vector3[] positions = FindActiveDieObs();

        foreach (Vector3 effectPosition in positions)
        {
            GameObject effect = Instantiate(explosionPrefabs, effectPosition, Quaternion.identity);
            //Debug.Log("이펙트 내부 위치 " + effect.transform.position);
            explosionPrefabs.SetActive(true);
            Destroy(effect, effectLifetime); // 일정 시간 뒤에 이펙트 오브젝트 삭제
        }
    }


}
