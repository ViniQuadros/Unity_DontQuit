using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private GameManager gameManager;
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private bool isDead = false;

    private AudioSource audioSource;
    public AudioClip deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }
    }

    void Update()
    {
        if (transform.position.y < -13f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        if (isDead) return;

        isDead = true;
        animator.SetBool("Die", true);
        rb.linearVelocity = Vector2.zero;
        playerMovement.isDead = true;
        audioSource.PlayOneShot(deathSound);
        StartCoroutine(DeathDelay());
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1.5f);
        gameManager.RestartLevel();
    }
}
