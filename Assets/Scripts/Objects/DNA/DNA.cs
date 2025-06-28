using UnityEngine;

public class DNA : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private DNA_Manager dnaManager;

    private void Start()
    {
        dnaManager = DNA_Manager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            SFXManager.instance?.PlayCollectSound();
            dnaManager.ChangeDNA(value);
            Destroy(gameObject);
        }
    }
}
