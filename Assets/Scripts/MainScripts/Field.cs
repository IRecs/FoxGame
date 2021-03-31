using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Vector2Int SpawnPoint => _spawnPoint;

    private Vector3[,] _pointsPositions;
    private Vector2Int _spawnPoint;
    private GameObject[,] _points;

    public Field(Vector3[,] pointsPositions, GameObject[,] points, Vector2Int spawnPoint, GameObject startPositionLock)
    {
        _pointsPositions = pointsPositions;
        _points = points;
        _spawnPoint = spawnPoint;
        SetPointContent(_spawnPoint, startPositionLock);
    }       

    public bool GetPointPosition(Vector2Int pointNumber, out Vector3 pointsPosition)
    {
        pointsPosition = Vector3.zero;

        if (pointNumber.x >= _pointsPositions.GetLength(0) | pointNumber.x < 0)
            return false;
        if (pointNumber.y >= _pointsPositions.GetLength(1) | pointNumber.y < 0)
            return false;

        pointsPosition = _pointsPositions[pointNumber.x, pointNumber.y];
        return true;
    }

    public bool GetPointContent(Vector2Int pointNumber, out GameObject content)
    {
        content = null;

        if (!CheckCoordinates(pointNumber, _points))
            return false;

        content = _points[pointNumber.x, pointNumber.y];
        return true;
    }

    public bool SetPointContent(Vector2Int pointNumber, GameObject content)
    {
        if (!CheckCoordinates(pointNumber, _points))
            return false;
            
        _points[pointNumber.x, pointNumber.y] = content;

        return true;
    }

    private bool CheckCoordinates(Vector2Int pointNumber, GameObject[,] array)
    {
        if (pointNumber.x >= array.GetLength(0) | pointNumber.x < 0)
            return false;
        if (pointNumber.y >= array.GetLength(1) | pointNumber.y < 0)
            return false;
        return true;
    }

    public bool FindingFreePoint(out Vector2Int freePoint)
    {
        List<Vector2Int> freePoints = new List<Vector2Int>();

        for (int i = 0; i < _points.GetLength(0); i++)
        {
            for (int j = 0; j < _points.GetLength(1); j++)
            {
                if(_points[i,j] == null)
                {
                    freePoints.Add(new Vector2Int(i, j));
                }
            }
        }

        if (freePoints.Count != 0)
        {
            freePoint = freePoints[Random.Range(0, freePoints.Count)];
            return true;
        }
        else
        {
            freePoint = Vector2Int.zero;
            return false;
        }
    }    
}
