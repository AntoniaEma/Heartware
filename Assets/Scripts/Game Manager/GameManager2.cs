using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fallThreshold = -10f;
    [SerializeField] private string gameOverSceneName = "GameOver";
    [SerializeField] private LVL2_Health playerHealth;
    [SerializeField] private float delayBeforeGameOver = 2f;

    private bool gameOverTriggered = false;

    private void Update()
    {
        if (!gameOverTriggered && (playerTransform.position.y < fallThreshold || playerHealth.currentHealth <= 0))
        {
            gameOverTriggered = true;
            StartCoroutine(LoadGameOverWithDelay());
        }
    }

    private IEnumerator LoadGameOverWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeGameOver);
        SceneManager.LoadScene(gameOverSceneName);
    }
}
