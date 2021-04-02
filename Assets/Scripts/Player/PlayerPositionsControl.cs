using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MoverPlayer))]

public class PlayerPositionsControl : MonoBehaviour
{
    public event UnityAction<Vector2Int, Quaternion> RefreshPoint;
    
    private CollisionHandling _collisionHandling;
    private MoverPlayer _moverPlayer;

    private Vector2Int _curentPointNumber, _targetPointNumber;
    private Point _curentPoint, _targetPoint;

    private Vector2Int _direction;

    private void OnEnable()
    {
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
        _targetPointNumber = field.SpawnPoint;

        field.GetPoint(_targetPointNumber, out Point spawnPoint);
        _targetPoint = spawnPoint;
        transform.position = spawnPoint.GetPointPosition();
    }

    public void SetDirection(Vector2Int direction)
    {
        _direction = direction;        
    }

    public void ChangeCurentPosition()
    {
        _curentPointNumber = _targetPointNumber;
        _curentPoint = _targetPoint;
        _curentPoint.SetPointContent(gameObject);

        RefreshTargetPoint();
    }

    public bool RefreshTargetPoint()
    {
        _targetPointNumber = _curentPointNumber + _direction;

        if (_collisionHandling.DefineTargetPoint(_targetPointNumber, out _targetPoint))
        {
            RefreshPoint?.Invoke(_curentPointNumber, transform.rotation);
            _moverPlayer.SetTargetPosition(_targetPoint.GetPointPosition());
            return true;
        }

        return false;
    }

    
}
