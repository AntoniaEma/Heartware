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
            treeObject.SetActive(false); 
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

            if (treeObject != null)
            {
                treeObject.SetActive(true);
                if (treeAnimator != null)
                    treeAnimator.Play("Tree", 0, 0);
            }

            gameObject.SetActive(false);

            if (seedsManager != null)
                seedsManager.ChangeSeeds(value);
        }
    }
}
