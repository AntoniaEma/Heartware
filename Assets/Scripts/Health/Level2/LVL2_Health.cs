using System.Collections;
using UnityEngine;

public class LVL2_Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth- _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            SFXManager.instance?.PlayDamageSound();
            anim.SetTrigger("isHurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("isDead");
                GetComponent<EVEMovement>().enabled = false;
                dead = true;
            }
            
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
