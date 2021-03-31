using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MoverPlayer))]

public class PlayerPositionsControl : MonoBehaviour
{
    public event UnityAction<Vector2Int, Quaternion> RefreshPoint;

    private Field _field;
    private Animator _animator;
    private CollisionHandling _collisionHandling;
    private MoverPlayer _moverPlayer;
    private Vector2Int _curentPointNumber;
    private Vector2Int _targetPointNumber;
    private Vector2Int _direction;
    private Vector3 _targetPosition;
    private bool _isFirstStep = true;

    private void OnEnable()
    {
        _animator = GetComponentInChildren<Animator>();
        _moverPlayer = GetComponent<MoverPlayer>();
        _moverPlayer.NexStep += ChangeCurentPosition;
    }

    private void OnDisable()
    {
        _moverPlayer.NexStep -= ChangeCurentPosition;
    }

    public void SetCollisionHandling(CollisionHandling collisionHandling)
    {
        _collisionHandling = collisionHandling;
    }
    public void SetField(Field field)
    {
        _field = field;
        _curentPointNumber = field.SpawnPoint;

        field.GetPointPosition(field.SpawnPoint, out Vector3 spawnPosition);
        transform.position = spawnPosition;
    }

    public void SetDirection(Vector2Int direction)
    {
        _direction = direction;
        if (_isFirstStep)
        {
            _animator.SetBool("Move", true);
            ChangeCurentPosition();
        }
    }

    public void ChangeCurentPosition()
    {
        if (!_isFirstStep)
        {
            _curentPointNumber = _targetPointNumber;
            _field.SetPointContent(_curentPointNumber, gameObject);
        }

        _isFirstStep = false;
        RefreshTargetPoint();
    }

    public bool RefreshTargetPoint()
    {
        _targetPointNumber = _curentPointNumber + _direction;

        if (_collisionHandling.DefineTargetPoint(_targetPointNumber, out _targetPosition))
        {
            RefreshPoint?.Invoke(_curentPointNumber, transform.rotation);
            _moverPlayer.SetTargetPosition(_targetPosition);
            return true;
        }

        return false;
    }

    
}
