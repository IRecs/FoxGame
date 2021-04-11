using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private Vector2Int _sizeMap;
    [SerializeField] private Vector2Int _startPoint;
    [SerializeField] private FieldSpawner _fieldSpawner;
    [SerializeField] private DeterminingTargetPosition _playerPositionControl;
    [SerializeField] private FireSpawner _fireSpawner;
    [SerializeField] private GameObject _fireTemplates;
    [SerializeField] private FirePower _firePower;
    [SerializeField] private Bonus _bonus;
    [SerializeField] private CollisionHandling _collisionHandling;
    [SerializeField] private EndGame _endGame;

    private void Start()
    {
        Field field = gameObject.AddComponent<Field>();
        field = _fieldSpawner.CreatingField(_sizeMap, _startPoint);        

        _collisionHandling.SetField(field);
        _collisionHandling.SetFireInfo(_firePower);

        _playerPositionControl.SetField(field);
        _playerPositionControl.SetCollisionHandling(_collisionHandling);

        _fireSpawner.SetFildAndPlayerPositionsControl(field, _playerPositionControl);
        _fireSpawner.Initialize(_fireTemplates, _sizeMap.x * _sizeMap.y);

        _bonus.SetField(field);
    }
}
