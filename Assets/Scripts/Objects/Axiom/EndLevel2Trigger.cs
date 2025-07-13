using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndLevel2Trigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Level2_Puzzle";
    [SerializeField] private float delayBeforeSceneChange = 3f;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Player") && DNA_Manager.instance.HasCollectedAllDNA())
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
        Animator EVEAnimator = collision.GetComponent<Animator>();
        if (EVEAnimator != null)
            EVEAnimator.Play("EVE_Lvl2_Laughing");

        // Animatia EVE
        Animator AxiomAnimator = GetComponent<Animator>();
        if (AxiomAnimator != null)
            AxiomAnimator.Play("Axiom");

        // Oprire miscare Wall-E
        EVEMovement eveMovement = collision.GetComponent<EVEMovement>();
        if (eveMovement != null)
            eveMovement.enabled = false;

        // Oprire fizică (cade în gol altfel)
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

        // Așteaptă restul de delay și încarcă următoarea scenă
        yield return new WaitForSeconds(delayBeforeSceneChange);
        SceneManager.LoadScene(nextSceneName);
    }
}
