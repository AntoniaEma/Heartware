using UnityEngine;
using TMPro;

public class SeedsManager : MonoBehaviour
{
    [SerializeField] private int requiredSeeds;
    [SerializeField] private TMP_Text seedsDisplay;
    public bool HasCollectedAllSeeds() => seeds >= requiredSeeds;
    public static SeedsManager instance;
    private int seeds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        seedsDisplay.text = seeds.ToString();
    }

    public void ChangeSeeds(int amount)
    {
        seeds += amount;
    }
}
