using UnityEngine;
using TMPro;

public class DNA_Manager : MonoBehaviour
{
    [SerializeField] private int requiredDNA;
    public bool HasCollectedAllDNA() => dna >= requiredDNA;
    [SerializeField] private TMP_Text dnaDisplay;
    public static DNA_Manager instance;
    private int dna;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void OnGUI()
    {
        dnaDisplay.text = dna.ToString();
    }

    public void ChangeDNA(int amount)
    {
        dna += amount;
    }
}
