using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FireControl))]

public class FireSpawner : ObjectPool
{
    private PlayerPositionsControl _playerPositionsControl;
    private Field _field;
    private FireControl _fireControl;
    private float _heightCorrection = 0.019f;

    public void SetFildAndPlayerPositionsControl(Field field, PlayerPositionsControl playerPositionsControl)
    {
        _field = field;
        _fireControl.SetField(field);
        _playerPositionsControl = playerPositionsControl;
        _playerPositionsControl.RefreshPoint += SetFire;
    }

    private void OnEnable()
    {
        _fireControl = GetComponent<FireControl>();
    }

    private void OnDisable()
    {
        _playerPositionsControl.RefreshPoint -= SetFire;
    }

    private void SetFire(Vector2Int spawnPointNumber, Quaternion rotation)
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

                float firePower = _fireControl.GetFirePower();
                fire.GetComponent<Fire>().SetFirePower(firePower);
                _fireControl.SetFire(fire.GetComponent<Fire>(), point);
                point.SetPointContent(fire);
            }
        }
    }
}
