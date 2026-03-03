using System.Collections;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [Header("Camera Scroll Settings")]
    public GameObject mainCamera;
    public float scrollDuration = 60f;
    public float scrollDistance = 100f;

    private bool isScrolling = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isScrolling)
        {
            StartCoroutine(ScrollUp());
        }
    }

    private IEnumerator ScrollUp()
    {
        isScrolling = true;

        Vector3 startPos = mainCamera.transform.position;
        Vector3 targetPos = startPos + new Vector3(0, scrollDistance, 0);

        float elapsed = 0f;
        while (elapsed < scrollDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPos, targetPos, elapsed / scrollDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPos;
        isScrolling = false;
    }
}
