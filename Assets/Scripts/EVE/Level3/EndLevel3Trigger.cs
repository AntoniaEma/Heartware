using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndLevel3Trigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Thanks";
    [SerializeField] private float delayBeforeSceneChange = 3f;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Player") && SeedsManager.instance.HasCollectedAllSeeds())
        {
            hasTriggered = true;
            StartCoroutine(TriggerEndSequence(collision));
        }
    }

    private IEnumerator TriggerEndSequence(Collider2D collision)
    {
        // Așteaptă 1 secundă
        yield return new WaitForSeconds(1f);

        // Animatia Wall-E
        Animator wallEAnimator = collision.GetComponent<Animator>();
        if (wallEAnimator != null)
            wallEAnimator.Play("HoldingPlant");

        // Animatia EVE
        Animator eveAnimator = GetComponent<Animator>();
        if (eveAnimator != null)
            eveAnimator.Play("Laughing");

        // Oprire miscare Wall-E
        PlayerMovement movement = collision.GetComponent<PlayerMovement>();
        if (movement != null)
            movement.enabled = false;

        // Așteaptă restul de delay și încarcă următoarea scenă
        yield return new WaitForSeconds(delayBeforeSceneChange);
        SceneManager.LoadScene(nextSceneName);
    }
}
