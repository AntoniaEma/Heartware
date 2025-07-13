using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Destroy(collision.gameObject); // stinge focul
            Destroy(gameObject); // distruge picătura
        }
    }
}