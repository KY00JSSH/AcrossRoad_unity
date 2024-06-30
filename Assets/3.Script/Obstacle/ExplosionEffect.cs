using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject explosionPrefabs;

    [SerializeField] private float explosionDelayTime = 0.01f;
    [SerializeField] private float effectLifetime = 0.5f;


    // Hierarchy �� �ִ� Ȱ��ȭ �Ǿ��ִ� dieobs�� ã�ƿͼ� �ش� ��ġ ã�ƿ�
    private Vector3[] FindActiveDieObs()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        List<Vector3> activeVectors = new List<Vector3>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.activeInHierarchy && obj.CompareTag("DieObs"))
            {
                Debug.Log("���� Ȱ��ȭ �Ǿ��ִ� DieObs" + obj.name);
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
            //Debug.Log("����Ʈ ���� ��ġ " + effect.transform.position);
            explosionPrefabs.SetActive(true);
            Destroy(effect, effectLifetime); // ���� �ð� �ڿ� ����Ʈ ������Ʈ ����
        }
    }


}
