using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LVL2_Health health = collision.GetComponent<LVL2_Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            //SFXManager.instance?.PlayDamageSound();
        }
    }
}
