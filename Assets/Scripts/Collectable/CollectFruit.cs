using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    private PassLevel flag;
    private AudioSource audioSource;
    private SpriteRenderer sprite;

    public AudioClip collectSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        GameObject flagObject = GameObject.FindWithTag("Flag");
        if (flagObject != null)
        {
            flag = flagObject.GetComponent<PassLevel>();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            flag.SetHasFruit();
            sprite.enabled = false;
            audioSource.PlayOneShot(collectSound);
            Destroy(gameObject, collectSound.length);
        }
    }
}
