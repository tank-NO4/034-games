using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIBreathing : MonoBehaviour
{
    public float speed = 1.5f;
    [Range(0f, 360f)] public float phaseOffset = 0f;
    public Color baseColor = Color.white;
    [Range(0f, 1f)] public float minBrightness = 0f; // 最小亮度/透明度
    public bool useAlphaBreath = false;

    private Image image;
    private Color originalColor;

    void Start()
    {
        image = GetComponent<Image>();
        originalColor = baseColor;
        image.color = originalColor;
    }

    void Update()
    {
        float phaseRad = phaseOffset * Mathf.Deg2Rad;
        float t = 0.5f + 0.5f * Mathf.Sin(Time.time * speed + phaseRad);
        float factor = Mathf.Lerp(minBrightness, 1f, t);

        if (useAlphaBreath)
        {
            Color newColor = originalColor;
            newColor.a = originalColor.a * factor;
            image.color = newColor;
        }
        else
        {
            Color newColor = originalColor * factor;
            newColor.a = originalColor.a;
            image.color = newColor;
        }
    }
}