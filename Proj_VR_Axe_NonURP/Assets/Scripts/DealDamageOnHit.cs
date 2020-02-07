using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<IReceiveDamage>() != null)
        {
            other.collider.GetComponent<IReceiveDamage>().GetHit();
        }
    }
}
