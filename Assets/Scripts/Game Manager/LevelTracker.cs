using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    public static string LastLevelName;

    private void Awake()
    {
        LastLevelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
