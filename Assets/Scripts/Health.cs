using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer dmgDealer = collision.GetComponent<DamageDealer>();
        if (dmgDealer != null)
        {
            TakeDmg(dmgDealer);
            dmgDealer.Hit();
        }
    }

    void TakeDmg(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDmgAmount();
        if (health <= 0) Destroy(gameObject);
    }
}
