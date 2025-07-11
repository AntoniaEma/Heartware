using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL2_HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<LVL2_Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
