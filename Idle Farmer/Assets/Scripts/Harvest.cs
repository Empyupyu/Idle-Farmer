using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Harvest : Movable
{
    [SerializeField] private int _cost = 15;

    [SerializeField] private Collider _collider;
    
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Coin _coin;

    private Transform _coinHandler;

    private bool _isPickUp;
    public int Cost => _cost;

    public void PickUpToStack(Vector3 localMovePosition)
    {
        _collider.isTrigger = true;

        _rigidbody.isKinematic = true;

        transform.DOLocalMove(localMovePosition, MoveTime);

        transform.DOLocalRotateQuaternion(Quaternion.identity, MoveTime);

        transform.DOScale(transform.localScale / 3, MoveTime);
    }

    public void PickUp()
    {
        _isPickUp = true;
    }

    public void SellAnimation(Transform barn, Transform coinHandler)
    {
        _coinHandler = coinHandler;

        MoveToLocalZero(barn);
    }

    protected override void MoveCompleted()
    {
        base.MoveCompleted();

        Coin coin = Instantiate(_coin, transform.position, _coin.transform.rotation);

        coin.SetValue(_cost);

        coin.MoveToLocalZero(_coinHandler);
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<Character>();

        if(!_isPickUp && character != null)
        {        
            character.Harvesting(this);
        }
    } 
}
