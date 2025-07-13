using UnityEngine;

public class TrashPile : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private TrashManager trashManager;

    private void Start()
    {
        trashManager = TrashManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            SFXManager.instance?.PlayCollectSound();
            trashManager.ChangeTrash(value);
            Destroy(gameObject);
        }
    }
}
