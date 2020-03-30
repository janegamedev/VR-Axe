using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHealth : MonoBehaviour, IReceiveDamage
{
    public int health = 5;
    public void GetHit()
    {
        health--;
        Debug.Log("Health remaining: " + health);
        if (health <= 0)
        {
            //Game Over
        }
    }
}
