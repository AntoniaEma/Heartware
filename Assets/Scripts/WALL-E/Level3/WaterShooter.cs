using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private Transform firePoint; // locul de unde pleacă apa
    [SerializeField] private float shootForce = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootWater();
        }
    }

    private void ShootWater()
    {
        GameObject water = Instantiate(waterPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = water.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            rb.velocity = direction * shootForce;
        }
    }
}
