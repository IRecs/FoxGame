using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPositionsControl : MonoBehaviour
{
    private Field _field;
    private Bonus _bonus;
    private float _heightCorrection = 1f;
    [SerializeField] private float _timeToWait = 1;

    public void SetField(Field field)
    {
        _field = field;      
    }

    public void SetBonus(Bonus bonus)
    {
        _bonus = bonus;
        ChangePositionBonus();
    }

    public void ChangePositionBonus()
    {
        if(_field.FindingFreePoint(out Vector2Int freePoint))
        {
            _field.GetPointPosition(freePoint, out Vector3 position);
            position.y += _heightCorrection;
            _bonus.transform.position = position;
            _field.SetPointContent(freePoint, _bonus.gameObject);
        }        
    }
}
