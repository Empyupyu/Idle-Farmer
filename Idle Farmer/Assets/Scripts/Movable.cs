using DG.Tweening;
using System.Collections;
using UnityEngine;

public abstract class Movable: MonoBehaviour
{
    [SerializeField] private float _moveTime;

    private IEnumerator _coroutine; 

    public float MoveTime => _moveTime;

    public void MoveToLocalZero(Transform parent)
    {
        if (_coroutine != null) return;

        transform.parent = parent;

        _coroutine = MoveToLocalZeroRoutine();

        StartCoroutine(_coroutine);
    }

    private IEnumerator MoveToLocalZeroRoutine()
    {
        Tween coinTween = transform.DOLocalMove(Vector3.zero, _moveTime).SetEase(Ease.InSine);

        yield return coinTween.WaitForPosition(1f);

        MoveCompleted();
    }

    protected virtual void MoveCompleted()
    {
        _coroutine = null;
    }
}
