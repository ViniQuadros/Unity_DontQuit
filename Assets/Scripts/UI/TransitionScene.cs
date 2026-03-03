using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScene : MonoBehaviour
{
    private Image transitionImage;
    float initialScale = 20f;
    float targetScale = 0f;

    void Start()
    {
        transitionImage = GetComponent<Image>();
        transitionImage.transform.localScale = new Vector3(initialScale, initialScale, 0);
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            transitionImage.transform.localScale = Vector2.Lerp(new Vector2(initialScale, initialScale), new Vector2(targetScale, targetScale), elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transitionImage.enabled = false;
    }
}
