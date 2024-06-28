using UnityEngine;

public class WallTransparent : MonoBehaviour {
    private Transform playerTransform;
    private Renderer renderer;
    private Material material;
    private Color materialColor;
    private float distance;

    private void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        TryGetComponent(out renderer);
        material = renderer.material;
    }

    private void Update() {
        if (transform.position.x > 0)
            distance = Mathf.Abs(transform.position.x - playerTransform.position.x);
        else if (transform.position.z < 0)
            distance = Mathf.Abs(transform.position.z - playerTransform.position.z);
        else distance = 100;

        materialColor = material.color;
        if (distance < 8) 
            materialColor.a = distance / 10;

        material.color = materialColor;
    }
}