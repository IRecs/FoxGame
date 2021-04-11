using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Vector3 _positions;
    private GameObject _content;

    public Point(Vector3 pointPositions, GameObject pointContent)
    {
        _content = pointContent;
        _positions = pointPositions;
    }

    public Vector3 GetPointPosition()
    {        
        return  _positions;
    }

    public GameObject GetPointContent()
    {
        return _content;
    }

    public void SetPointContent(GameObject content)
    {
        if(content != _content)
            _content = content;
    }
}
