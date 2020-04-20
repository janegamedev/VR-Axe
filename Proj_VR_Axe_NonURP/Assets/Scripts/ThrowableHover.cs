using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ThrowableHover : MonoBehaviour
{
    private bool _isHovering = true;

    [SerializeField]  private Vector2 heightMinMax;

    private Sequence _mySequence;
    private bool _isPlaying;
    private bool _flip;

    public Transform currentHoverPoint;

    public bool IsHovering
    {
        set
        {
            _isHovering = value;
            OnStatusChange();
        } 
    }

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mySequence = DOTween.Sequence();
    }
    
    public void OnStatusChange()
    {
        _rigidbody.useGravity = !_isHovering;
        _rigidbody.isKinematic = _isHovering;
    }

    private void Update()
    {
        if (!_isHovering)
        {
            StopAllCoroutines();
            return;
        }
        if (_isHovering && !_isPlaying)
        {
            if (_flip)
            {
                StartCoroutine(PingPong(heightMinMax.x));
            }
            else
            {
                StartCoroutine(PingPong(heightMinMax.y));
            }
        }
    }

    private IEnumerator PingPong(float displacement)
    {

        _flip = !_flip;
        _isPlaying = true;
        _mySequence.Append(transform.DOLocalMoveY(transform.localPosition.y + displacement, .5f).SetEase(Ease.InOutSine));
        _mySequence.Play();
        yield return new WaitForSeconds(.5f);
        //KillTween();
        _isPlaying = false;
        
    }

    public void KillTween()
    {
        _mySequence.Kill();
        _isHovering = false;
        _isPlaying = false;
        //_mySequence.Pause();
    }

    public void ClearDictionary()
    {
        ThrowableManager.Instance.spawnPositions[currentHoverPoint] = null;
    }

    public void UpdateDictionary()
    {
        ThrowableManager.Instance.SpawnBack(gameObject);
    }
}
