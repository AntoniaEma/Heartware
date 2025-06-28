using UnityEngine;
using UnityEngine.UI;

public class LVL2_HealthBar : MonoBehaviour
{
    [SerializeField] private LVL2_Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
