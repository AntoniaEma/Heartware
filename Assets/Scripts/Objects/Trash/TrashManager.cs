using UnityEngine;
using TMPro;

public class TrashManager : MonoBehaviour
{
    [SerializeField] private int requiredTrash;
    public bool HasCollectedAllTrash() => trash >= requiredTrash;
    [SerializeField] private TMP_Text trashDisplay;
    public static TrashManager instance;
    private int trash;

    private void Awake()
    {
        if (!instance)
            instance = this; 
    }

    private void OnGUI()
    {
        trashDisplay.text = trash.ToString();
    }

    public void ChangeTrash(int amount)
    {
        trash += amount;
    }
}
