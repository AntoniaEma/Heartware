using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    [SerializeField] private string correctBinTag;

    private Vector3 initialPosition;
    private bool isDroppedCorrectly = false;

    

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    private void OnMouseUp()
    {
        if (isDroppedCorrectly)
        {
            Destroy(gameObject); // Obiectul dispare
        }
        else
        {
            transform.position = initialPosition; // Revine la poziția inițială
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(correctBinTag))
        {
            isDroppedCorrectly = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(correctBinTag))
        {
            isDroppedCorrectly = false;
        }
    }

    public bool IsSortedCorrectly()
    {
        return isDroppedCorrectly;
    }
}
