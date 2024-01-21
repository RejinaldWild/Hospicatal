using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    
    [SerializeField] private GameObject _pauseMenuUI;

    private Scene _scene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Time.timeScale = 1f;
        IsGamePaused = false;
        SceneManager.LoadScene("MainMenu");       
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Application.Quit();
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        _scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        IsGamePaused = false;
        SceneManager.LoadScene(_scene.buildIndex);
    }

    private void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
}
