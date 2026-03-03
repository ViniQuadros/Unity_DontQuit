using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int deathCounter { get; private set; } = 0;
    public int levelIndex { get; private set; }

    private AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }


    private void Start()
    {

    }

    public void NextLevel()
    {
        try
        {
            levelIndex++;
            SceneManager.LoadScene(levelIndex);
        }
        catch
        {
            Debug.Log("No more levels! Game Completed.");
        }
    }

    public void RestartLevel()
    {
        deathCounter++;
        SceneManager.LoadScene(levelIndex);
    }

    public void ResetGame()
    {
        deathCounter = 0;
        levelIndex = 1;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(levelIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
