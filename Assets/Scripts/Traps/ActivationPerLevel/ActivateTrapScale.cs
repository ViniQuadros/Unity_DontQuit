using System.Collections;
using UnityEngine;

public class ActivateTrapScale : MonoBehaviour
{
    public GameObject trap;
    public float scaleDuration = 2f;
    public Vector3 scaleLimit = new Vector3(10f, 10f, 10f);
    private Vector3 initialScale;
    private bool isScaling = false;

    private AudioSource audioSource;
    private AudioClip trapSound;

    private void Start()
    {
        initialScale = trap.transform.localScale;
        audioSource = GetComponent<AudioSource>();
        trapSound = Resources.Load<AudioClip>("Show_Trap");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isScaling)
        {
            isScaling = true;
            audioSource.PlayOneShot(trapSound);
            StartCoroutine(IncreaseScale());
        }
    }

    private IEnumerator IncreaseScale()
    {
        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            float f = elapsedTime / scaleDuration;
            trap.transform.localScale = Vector3.Lerp(initialScale, scaleLimit, f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isScaling = false;
        trap.transform.localScale = scaleLimit;
    }
}
