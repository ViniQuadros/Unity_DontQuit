using TMPro;
using UnityEngine;

public class TotalDeaths : MonoBehaviour
{
    public TMP_Text deathTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance != null)
        {
            deathTxt.text = $"Total Deaths: {GameManager.Instance.deathCounter}";
        }
        else
        {
            deathTxt.text = "Total Deaths: 0";
        }
    }
}
