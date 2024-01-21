using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "TheEnd")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        Debug.Log("Button is clicked!");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Application.Quit();
        Debug.Log("Quit pressed!");
    }
}
