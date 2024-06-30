using UnityEngine;

public class CloudControl : MonoBehaviour {
    private void Update() {
        if (transform.position.x < -30) gameObject.SetActive(false);
        transform.Translate(Vector3.left * Time.deltaTime);
    }
}
