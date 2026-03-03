using System.Collections;
using UnityEngine;

public class ActivateTrapLeft : MonoBehaviour
{
    public GameObject trap;
    public float moveDuration = 0.1f;
    public float moveDistance = 1f;
    public float backDuration = 2f;

    private bool isActivated = false;
    public bool isLeft = true;
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
            if (isLeft)
                StartCoroutine(MoveLeftThenBack());
            else
                StartCoroutine(MoveRightThenBack());
        }
    }

    private IEnumerator MoveLeftThenBack()
    {
        yield return MoveLeft();

        if (backToPosition)
            yield return BackToPosition();
    }

    private IEnumerator MoveRightThenBack()
    {
        yield return MoveRight();

        if (backToPosition)
            yield return BackToPosition();
    }

    private IEnumerator MoveLeft()
    {
        Vector2 startPos = trap.transform.position;
        Vector2 targetPos = startPos + Vector2.left * moveDistance;

        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            trap.transform.position = Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        trap.transform.position = targetPos;
        isActivated = true;
    }

    private IEnumerator MoveRight()
    {
        Vector2 startPos = trap.transform.position;
        Vector2 targetPos = startPos + Vector2.right * moveDistance;

        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            trap.transform.position = Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        trap.transform.position = targetPos;
        isActivated = true;
    }

    private IEnumerator BackToPosition()
    {
        Vector2 startPos = trap.transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < backDuration)
        {
            trap.transform.position = Vector2.Lerp(startPos, initialPosition, elapsedTime / backDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        trap.transform.position = initialPosition;
        isActivated = false;
    }
}
