using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 target = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
    }
}
