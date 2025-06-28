using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_Camera : MonoBehaviour
{
    public void ReplayLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
