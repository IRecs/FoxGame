using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Vector2Int SpawnPoint => _spawnPoint;

    private Vector2Int _spawnPoint;
    private Point[,] _points;

    public Field(Point[,] points, Vector2Int spawnPoint)
    {
        _points = points;
        _spawnPoint = spawnPoint;
    }  
    
    public bool GetPoint(Vector2Int pointNumber, out Point point)
    {
        point = null;

        if (pointNumber.x >= _points.GetLength(0) | pointNumber.x < 0)
            return false;
        if (pointNumber.y >= _points.GetLength(1) | pointNumber.y < 0)
            return false;

        point = _points[pointNumber.x, pointNumber.y];
        return true;
    }    

    public bool FindingFreePoint(out Point freePoint)
    {
        List<Point> freePoints = new List<Point>();

        for (int i = 0; i < _points.GetLength(0); i++)
        {
            for (int j = 0; j < _points.GetLength(1); j++)
            {
                if(_points[i,j] == null)
                {
                    freePoints.Add(_points[i, j]);
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
            freePoint = null;
            return false;
        }
    }    
}
