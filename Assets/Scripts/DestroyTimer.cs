using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Range(5, 15)] public float destroyTime;
    [Range(0, 5)] public float blinkStartTime;
    [Range(1, 5)] public float blinkSpeed;

    public Color endColor;
    private Color _DefaultColor;

    [HideInInspector] public bool isDestroyEnabled;

    private void Awake()
    {
        _DefaultColor = meshRenderer.material.color;
    }

    private void Update()
    {
        if (!isDestroyEnabled) return;

        if (destroyTime > 0)
        {
            destroyTime -= Time.deltaTime;
            if (destroyTime < blinkStartTime) MaterialsBlink();
        }
        else Destroy(gameObject);
    }

    private void MaterialsBlink()
    {
        meshRenderer.material.color = Color.Lerp(_DefaultColor, endColor, Mathf.PingPong(Time.time * blinkSpeed, 1));
    }
}
