using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MoverPlayer : MonoBehaviour
{
    public event UnityAction PointReached;

    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private bool _isCanChangePosition = true;
    private bool _isCanMove = false;

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        transform.LookAt(_targetPosition);
        _isCanChangePosition = true;
        _isCanMove = true;
    }

    private void FixedUpdate()
    {
        if (_isCanMove)
            Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
            if (_isCanChangePosition)
            {
                _isCanChangePosition = false;
                PointReached?.Invoke();
            }
    }

}
