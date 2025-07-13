using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void ReplayLevel()
    {
        if (!string.IsNullOrEmpty(LevelTracker.LastLevelName))
            SceneManager.LoadScene(LevelTracker.LastLevelName);
        else
            SceneManager.LoadScene("Level1"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
