using System;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject prefab;
    public Transform target;

    [ContextMenu("Do it")]
    public void SpawnWeaponNow()
    {
        Instantiate(prefab, target.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnWeaponNow();
        }
    }
}
