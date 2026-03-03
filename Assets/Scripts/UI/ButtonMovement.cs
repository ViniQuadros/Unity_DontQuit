using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public enum AnimationType
    {
        Pulse,
        Float
    }

    public AnimationType animationType = AnimationType.Pulse;
    public float pulseSpeed = 1.5f;
    public float amount = 0.1f;

    private RectTransform rectTransform;

    private Vector3 originalScale;
    private Vector3 originalPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        float sinWave = Mathf.Sin(Time.time * pulseSpeed);
        float t = (sinWave + 1f) / 2f;

        switch (animationType)
        {
            case AnimationType.Pulse:
                PulseAnimation(t);
                break;
            case AnimationType.Float:
                FloatAnimation(t);
                break;
        }
    }

    private void PulseAnimation(float t)
    {
        Vector3 minScale = originalScale;
        Vector3 maxScale = originalScale * (1f + amount);

        rectTransform.localScale = Vector3.Lerp(minScale, maxScale, t);
    }

    private void FloatAnimation(float t)
    {
        Vector3 minPosition = originalPosition;
        Vector3 maxPosition = originalPosition + new Vector3(0f, amount, 0f);
        rectTransform.anchoredPosition = Vector3.Lerp(minPosition, maxPosition, t);
    }
}
