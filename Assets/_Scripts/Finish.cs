using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name!= "TheEnd")
        {
            FindObjectOfType<AudioManager>().Play("FinishLevel");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
