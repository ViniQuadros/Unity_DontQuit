using System.Collections;
using UnityEngine;

public class PassLevel : MonoBehaviour
{
    private GameManager gameManager;
    private bool hasFruit;

    private AudioSource audioSource;
    public AudioClip levelCompleteSound;

    private void Start()
    {
        hasFruit = false;
        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hasFruit)
        {
            StartCoroutine(PlaySound());
        }
    }

    public void SetHasFruit()
    {
        hasFruit = true;
    }

    private IEnumerator PlaySound()
    {
        audioSource.PlayOneShot(levelCompleteSound);
        yield return new WaitForSeconds(levelCompleteSound.length);
        gameManager.NextLevel();
    }
}
