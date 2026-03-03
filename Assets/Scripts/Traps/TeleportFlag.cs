using UnityEngine;

public class TeleportFlag : MonoBehaviour
{
    public GameObject teleportedObject;
    public Transform teleportDestination;

    private AudioSource audioSource;
    public AudioClip teleportSound;

    private bool hasTeleported = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasTeleported)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(teleportSound);
            teleportedObject.transform.position = teleportDestination.position;
            hasTeleported = true;
        }
    }
}
