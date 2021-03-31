using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MoverPlayer : MonoBehaviour
{
    public event UnityAction NexStep;

    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private bool _isChangePosition = true;
    private bool _isCanMove = false;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        _transform.LookAt(_targetPosition);
        _isChangePosition = true;
        _isCanMove = true;
    }

    private void FixedUpdate()
    {
        if (_isCanMove)
            Move();
    }

    public void Move()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(_transform.position, _targetPosition) < 0.01f)
            if (_isChangePosition)
            {
                _isChangePosition = false;
                NexStep?.Invoke();
            }
    }

}
