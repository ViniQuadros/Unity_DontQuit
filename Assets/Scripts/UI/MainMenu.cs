using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip menuMusic;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StopMusic();
        }

        audioSource = GetComponent<AudioSource>();
        menuMusic = Resources.Load<AudioClip>("Menu_Music");
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StartGame()
    {
        GameManager.Instance.ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
