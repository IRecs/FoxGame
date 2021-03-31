using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[RequireComponent (typeof (PlayerPositionsControl))]
public class InputPlayer : MonoBehaviour
{
    private PlayerPositionsControl _positionControl;
    private Vector2Int _direction = new Vector2Int();
    private int _currentDirection = 1, _staticAxis = 0;
    private int _travelAxis = 1;

    private void Start()
    {
        _positionControl = GetComponent<PlayerPositionsControl>();
    }

    private void Update()
    {
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
        SwapAxis();

        if (_currentDirection == 1 && _travelAxis == 1)
            _currentDirection = -direction;
        else
            _currentDirection = direction;
        
        SetDirection();
    }

    private void SwapAxis()
    {
        int tempAxis = _travelAxis;
        _travelAxis = _staticAxis;
        _staticAxis = tempAxis;
    }

    private void SetDirection()
    {
        if(_travelAxis == 0)
        {
            _direction.x = _currentDirection;
            _direction.y = 0;
        }
        else
        {
            _direction.y = _currentDirection;
            _direction.x = 0;
        }
        _positionControl.SetDirection(_direction);
    }
}
