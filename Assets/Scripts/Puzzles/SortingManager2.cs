using UnityEngine;
using UnityEngine.SceneManagement;

public class SortingManager2 : MonoBehaviour
{
    [SerializeField] private DraggableItem2[] itemsToSort;

    private void Update()
    {
        if (AreAllItemsSorted())
        {
            Invoke("LoadNextScene", 1f); // Delay scurt
        }
    }

    private bool AreAllItemsSorted()
    {
        foreach (var item in itemsToSort)
        {
            if (item != null) return false;
        }
        return true;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level3");
    }
}
