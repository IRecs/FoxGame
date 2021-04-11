using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FirePool))]

public class FireSpawner : FirePool
{
    private DeterminingTargetPosition _playerPositionsControl;
    private Field _field;
    private FirePower _firePower;
    private float _heightCorrection = 0.019f;

    public void SetFildAndPlayerPositionsControl(Field field, DeterminingTargetPosition playerPositionsControl)
    {
        _field = field;
        _playerPositionsControl = playerPositionsControl;
        _playerPositionsControl.PositionСhanged += OnSetFire;
    }

    private void OnEnable()
    {
        _firePower = GetComponent<FirePower>();
    }

    private void OnDisable()
    {
        _playerPositionsControl.PositionСhanged -= OnSetFire;
    }

    private void OnSetFire(Vector2Int spawnPointNumber, Quaternion rotation)
    {
        if (TryGetObject(out GameObject fire))
        {
            fire.SetActive(true);
            if (_field.GetPoint(spawnPointNumber, out Point point))
            {
                Vector3 spawnPosition = point.GetPointPosition();
                spawnPosition.y += _heightCorrection;
                fire.transform.position = spawnPosition;
                fire.transform.rotation = rotation;

                float firePower = _firePower.GetFirePower();
                fire.GetComponent<Fire>().EnlargeFirePower(firePower);
                AddFire(fire.GetComponent<Fire>(), point);
                point.SetPointContent(fire);
            }
        }
    }
}
