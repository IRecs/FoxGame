using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[RequireComponent (typeof (DeterminingTargetPosition))]
[RequireComponent(typeof(Animation))]

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private float _timeWait;
    private float _currentTimeWait = 0;

    private Animator _animator;
    private DeterminingTargetPosition _positionControl;
    private Vector2Int _direction = new Vector2Int();
    private int _currentDirection = 1, _staticAxis = 0;
    private int _travelAxis = 1;

    private bool _isFirstStep = true;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _positionControl = GetComponent<DeterminingTargetPosition>();
    }

    private void Update()
    {
        _currentTimeWait -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetDirectionMove(-1);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetDirectionMove(1);
        }
    }

    public void SetDirectionMove(int direction)
    {
        if (_currentTimeWait <= 0)
        {
            _currentTimeWait = _timeWait;
            SwapAxis();

            if (_currentDirection == 1 && _travelAxis == 1)
                _currentDirection = -direction;
            else
                _currentDirection = direction;

            if (_travelAxis == 0)
            {
                _direction.x = _currentDirection;
                _direction.y = 0;
            }
            else
            {
                _direction.y = _currentDirection;
                _direction.x = 0;
            }

            _positionControl.ChangeDirection(_direction);

            if (_isFirstStep)
            {
                _isFirstStep = false;
                _animator.SetBool(AnimatorModelController.Params.Move, true);
                _positionControl.OnPointReached();
            }
        }
    }

    private void SwapAxis()
    {
        int tempAxis = _travelAxis;
        _travelAxis = _staticAxis;
        _staticAxis = tempAxis;
    }
}
