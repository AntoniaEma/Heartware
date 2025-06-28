using UnityEngine;

public class DraggableItem2 : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDroppedCorrectly = false;

    [SerializeField] private string correctCauseTag;

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
        if (other.CompareTag(correctCauseTag))
        {
            isDroppedCorrectly = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(correctCauseTag))
        {
            isDroppedCorrectly = false;
        }
    }

    public bool IsSortedCorrectly()
    {
        return isDroppedCorrectly;
    }
}
