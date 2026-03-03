using System.Collections;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public GameObject trap;
    public float moveDuration = 0.1f;
    public float moveDistance = 1f;
    public float returnDelay = 2f;

    private bool isActivated = false;
    public bool isUp = true;
    public bool backToPosition = false;

    private Vector2 initialPosition;

    private AudioSource audioSource;
    private AudioClip trapSound;

    private void Start()
    {
        initialPosition = trap.transform.position;
        audioSource = GetComponent<AudioSource>();
        trapSound = Resources.Load<AudioClip>("Show_Trap");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            audioSource.PlayOneShot(trapSound);
            if (isUp)
                StartCoroutine(MoveTrap(Vector2.up));
            else
                StartCoroutine(MoveTrap(Vector2.down));
        }
    }

    private IEnumerator MoveTrap(Vector2 direction)
    {
        isActivated = true;

        Vector2 startPos = trap.transform.position;
        Vector2 targetPos = startPos + direction * moveDistance;

        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            trap.transform.position = Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        trap.transform.position = targetPos;

        if (backToPosition)
        {
            yield return new WaitForSeconds(returnDelay);

            elapsedTime = 0f;
            while (elapsedTime < moveDuration)
            {
                trap.transform.position = Vector2.Lerp(targetPos, initialPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            trap.transform.position = initialPosition;
        }
    }
}
