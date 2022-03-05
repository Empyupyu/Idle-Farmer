using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _maximumStackValue = 40;

    [SerializeField] private float _movmentSpeed;

    [SerializeField] private Animator _animator;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Transform _stackPosition;

    [SerializeField] private FloatingJoystick _floatingJoystick;

    private List <Harvest> _currentStackValue = new List<Harvest>();

    private int _coins;

    public int Coins => _coins;
    public List<Harvest> CurrentStackValue => _currentStackValue;

    public delegate void CoinsChageCallBack(string value);

    public event CoinsChageCallBack CoinsChangeEvent;

    public delegate void StackChageCallBack(int value);

    public event StackChageCallBack StackChangeEvent;

    public void CoinsChage(int value)
    {
        _coins += value;

        CoinsChangeEvent?.Invoke(_coins.ToString());
    }

    public void Hit()
    {
        _animator.Play("Harvesting");
    }

    public void Harvesting(Harvest harvest)
    {
        if (_currentStackValue.Count >= _maximumStackValue) return;

         _currentStackValue.Add(harvest);

        harvest.PickUp();

        harvest.transform.SetParent(_stackPosition);
    
        Vector3 _currentCargoPosition = new Vector3(0, harvest.transform.lossyScale.y * (_currentStackValue.Count - 1), 0);
    
        harvest.PickUpToStack(_currentCargoPosition);
    
        StackChangeEvent?.Invoke(_currentStackValue.Count);
    }

    public void RemoveHarvestInStack(Harvest harvest)
    {
        _currentStackValue.Remove(harvest);

        StackChangeEvent?.Invoke(_currentStackValue.Count);
    }

    private void FixedUpdate()
    {
        if(_floatingJoystick.Horizontal != 0 || _floatingJoystick.Vertical != 0)
        {
            _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal * _movmentSpeed, _rigidbody.velocity.y, _floatingJoystick.Vertical * _movmentSpeed);

            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);

            _animator.SetBool("isRuning", true);
        }
        else
        {
            _animator.SetBool("isRuning", false);
        }
    }
}
