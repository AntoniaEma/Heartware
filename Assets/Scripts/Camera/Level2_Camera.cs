using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_Camera : MonoBehaviour
{
    public void ReplayLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
