using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThrowableManager : SingletonManager<ThrowableManager>
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private List<Transform> spawnPointList;
    public Dictionary<Transform , ThrowableHover> spawnPositions = new Dictionary<Transform, ThrowableHover>();

    [SerializeField] private GameObject spawnParticle;


    private void Awake()
    {
        base.Awake();
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        for (int i = 0; i < spawnPointList.Count; i++)
        {
            if (!spawnPositions.ContainsKey(spawnPointList[i]))
            {
                int rand = Random.Range(0, prefabs.Count);

                ThrowableHover go = Instantiate(prefabs[rand], spawnPointList[i].position, Quaternion.identity).GetComponent<ThrowableHover>();

                spawnPositions.Add(spawnPointList[i], go);
                go.currentHoverPoint = spawnPointList[i];
            }
        }
    }

    public void SpawnBack(GameObject go)
    {
        Transform temp = FindEmptyPosition();
        ThrowableHover hoverScript = go.GetComponent<ThrowableHover>();
        spawnPositions[temp] = hoverScript;
        hoverScript.currentHoverPoint = temp;
        GameObject particle = Instantiate(spawnParticle, temp.position, Quaternion.identity);
        go.SetActive(false);
        go.transform.position = temp.position;
        hoverScript.Rigidbody.velocity = Vector3.zero;
        hoverScript.IsHovering = true;
        StartCoroutine(ToggleObject(go));
        Destroy(particle, 2f);
    }

    public IEnumerator ToggleObject(GameObject go)
    {
        yield return new WaitForSeconds(.6f);
        go.SetActive(true);
    }

    public Transform FindEmptyPosition()
    {
        foreach (var kvp in spawnPositions)
        {
            if (kvp.Value == null)
            {
                return kvp.Key;
            }
        }
        return null;
    }
}
