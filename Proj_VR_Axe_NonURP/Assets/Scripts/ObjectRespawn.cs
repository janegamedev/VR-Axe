using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            other.GetComponent<ThrowableHover>().ResetObject();
        }
    }
}
