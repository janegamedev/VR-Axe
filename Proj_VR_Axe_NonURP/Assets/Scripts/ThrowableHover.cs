﻿using UnityEngine;
using Valve.VR.InteractionSystem;
using Random = UnityEngine.Random;

public class ThrowableHover : MonoBehaviour
{
    public bool _isHovering = true;

    public Transform currentHoverPoint;

    [SerializeField] private float amplitude = .5f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private Rigidbody _rigidbody;

    public bool IsHovering
    {
        set
        {
            _isHovering = value;
            OnStatusChange();
        } 
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.position += Vector3.up * Random.Range(-.5f, .5f);
    }

    public void OnStatusChange()
    {
        _rigidbody.useGravity = !_isHovering;
        //_rigidbody.isKinematic = _isHovering;
    }

    private void Update()
    {
        if (!_isHovering)
        {
            return;
        }
        transform.localPosition = currentHoverPoint.position + Vector3.up * (Mathf.Sin(Time.time * frequency) * amplitude);
    }
    
    public void ClearDictionary()
    {
        ThrowableManager.Instance.spawnPositions[currentHoverPoint] = null;
    }

    [ContextMenu("Boop")]
    public void ResetObject()
    {
        ThrowableManager.Instance.SpawnBack(gameObject);
        _rigidbody.isKinematic = true;
    }
}
