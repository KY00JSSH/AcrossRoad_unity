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
        if (transform.position.x.Equals(0)) 
            distance = Mathf.Abs(transform.position.z - playerTransform.position.z);
        else if (transform.position.z.Equals(0)) 
            distance = Mathf.Abs(transform.position.x - playerTransform.position.x);

        materialColor = material.color;
        if (distance < 8) 
            materialColor.a = distance / 10;
        else
            materialColor.a = 1;
        material.color = materialColor;

    }
}