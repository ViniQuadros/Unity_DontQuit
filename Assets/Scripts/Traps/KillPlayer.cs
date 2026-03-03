using UnityEngine;
public class KillPlayer : MonoBehaviour
{
    private PlayerLife playerLife;

    void Start()
    {
        playerLife = GameObject.FindWithTag("Player").GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerLife.Respawn();
        }
    }
}
