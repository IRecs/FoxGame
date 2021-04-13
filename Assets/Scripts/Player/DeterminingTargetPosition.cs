using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MoverPlayer))]

public class DeterminingTargetPosition : MonoBehaviour
{
    public event UnityAction<Vector2Int, Quaternion> PositionСhanged;
    
    private CollisionHandling _collisionHandling;
    private MoverPlayer _moverPlayer;

    private Vector2Int _curentPointNumber, _targetPointNumber;
    private Point _curentPoint, _targetPoint;

    private Vector2Int _direction;
    private bool _canChangeDirection = true;
    private float _timeWaite = 0.3f;

    private void OnEnable()
    {
        _moverPlayer = GetComponent<MoverPlayer>();
        _moverPlayer.PointReached += OnPointReached;
    }

    private void OnDisable()
    {
        _moverPlayer.PointReached -= OnPointReached;
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

    public void ChangeDirection(Vector2Int direction)
    {
        if (_canChangeDirection && direction != Vector2Int.zero)
        {
            _direction = direction;
            _canChangeDirection = false;
            StartCoroutine(WaitChangeDirection());
        }
    }

    private IEnumerator WaitChangeDirection()
    {
        yield return new WaitForSeconds(_timeWaite);
        _canChangeDirection = true;
    }

    public void OnPointReached()
    {
        _curentPointNumber = _targetPointNumber;
        _curentPoint = _targetPoint;
        _curentPoint.SetPointContent(gameObject);
        PositionСhanged?.Invoke(_curentPointNumber, transform.rotation);
        TryRefreshTargetPoint();
    }

    public bool TryRefreshTargetPoint()
    {
        _targetPointNumber = _curentPointNumber + _direction;

        if (_collisionHandling.DefineTargetPoint(_targetPointNumber, out _targetPoint))
        {
            _moverPlayer.SetTargetPosition(_targetPoint.GetPointPosition());
            return true;
        }

        return false;
    }    
}
