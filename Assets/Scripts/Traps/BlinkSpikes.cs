using System.Collections;
using UnityEngine;

public class BlinkSpikes : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Blink());
    }

    private IEnumerator Blink() 
    { 
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++) 
        { 
            spriteRenderer.enabled = false; 
            yield return new WaitForSeconds(0.2f); 
            spriteRenderer.enabled = true; 
            yield return new WaitForSeconds(0.2f);
        }
    }
}
