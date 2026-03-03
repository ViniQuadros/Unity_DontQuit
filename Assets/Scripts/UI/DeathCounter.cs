using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public TMP_Text deathTxt;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            deathTxt.text = $"Death Counter: {GameManager.Instance.deathCounter}";
        }
        else
        {
            deathTxt.text = "Death Counter: ?";
        }
    }
}
