using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class FieldSpawner : MonoBehaviour
{
    [SerializeField] private float _stepSpawnDistance;
    private Vector3[,] _pointsPositions;
    private Vector2Int _spawnPoint = new Vector2Int(0,0);

    public Field CreatingField(Vector2Int sizeMap, Vector2Int startPoint)
    {
        GameObject[,] points = new GameObject[sizeMap.x, sizeMap.y];
        Vector3[,] pointsPosition = new Vector3[sizeMap.x, sizeMap.y];
        Vector2Int positionNumber = new Vector2Int();

        int size = sizeMap.x * sizeMap.y;
        _spawnPoint = startPoint;

        for (int i = 0; i < size; i++)
        {
            positionNumber.y = (i / sizeMap.x);
            positionNumber.x = ((i % sizeMap.x));                     

            pointsPosition[positionNumber.x, positionNumber.y] = DefinePosition(positionNumber);
        }
        _pointsPositions = pointsPosition;
        Field field = new Field(pointsPosition, points, _spawnPoint, gameObject);

        return field;
    }


    private Vector3 DefinePosition(Vector2 positionNumber)
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = transform.position.x + (_stepSpawnDistance * positionNumber.x);
        spawnPosition.y = transform.position.y;
        spawnPosition.z = transform.position.z + (_stepSpawnDistance * positionNumber.y);

        return spawnPosition;
    }
}
