using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class FieldSpawner : MonoBehaviour
{
    [SerializeField] private float _stepSpawnDistance;
    private Point[,] _points;

    public Field CreatingField(Vector2Int sizeMap, Vector2Int startPoint)
    {
        _points = new Point[sizeMap.x, sizeMap.y];
        Vector2Int positionNumber = new Vector2Int();

        int size = sizeMap.x * sizeMap.y;

        for (int i = 0; i < size; i++)
        {
            positionNumber.y = (i / sizeMap.x);
            positionNumber.x = ((i % sizeMap.x));

            Vector3 pointPosition = DefinePosition(positionNumber);

            if(positionNumber == startPoint)
                _points[positionNumber.x, positionNumber.y] = new Point(pointPosition, gameObject);
            else
                _points[positionNumber.x, positionNumber.y] = new Point(pointPosition, null);
        }

        Field field = new Field(_points, startPoint);

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
