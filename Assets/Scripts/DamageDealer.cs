using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int dmgAmount = 10;

    public int GetDmgAmount()
    {
        return dmgAmount;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
