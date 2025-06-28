using UnityEngine;

public class SeedToTree : MonoBehaviour
{
    [SerializeField] private GameObject treeObject;
    [SerializeField] private int value;
    private Animator treeAnimator;
    private bool hasTransformed = false;
    private SeedsManager seedsManager;

    private void Awake()
    {
        if (treeObject != null)
        {
            treeAnimator = treeObject.GetComponent<Animator>();
            treeObject.SetActive(false); // se asigură că este invizibil până e nevoie
        }
    }

    private void Start()
    {
        seedsManager = SeedsManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTransformed) return;

        if (collision.CompareTag("Player"))
        {
            hasTransformed = true;

            SFXManager.instance?.PlayCollectSound();

            // Activează copacul și redă animația
            if (treeObject != null)
            {
                treeObject.SetActive(true);
                if (treeAnimator != null)
                    treeAnimator.Play("Tree", 0, 0); // redă de la început
            }

            // Dezactivează punga de semințe
            gameObject.SetActive(false);

            // Actualizează scorul
            if (seedsManager != null)
                seedsManager.ChangeSeeds(value);
        }
    }
}
