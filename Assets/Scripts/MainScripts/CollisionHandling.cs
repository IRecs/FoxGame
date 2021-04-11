using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EndGame))]

public class CollisionHandling : MonoBehaviour
{    
    private EndGame _endGame;
    private Field _field;
    private FirePower _firePower;
    
    private void Start()
    {
        _endGame = GetComponent<EndGame>();
    }

    public void SetField(Field field)
    {
        _field = field;
    }

    public void SetFireInfo(FirePower firePower)
    {
        _firePower = firePower;        
    }

    public bool DefineTargetPoint(Vector2Int targetPointNumber, out Point targetPoint)
    {
        if (_field.GetPoint(targetPointNumber, out Point point))
        {
            GameObject content = point.GetPointContent();

            if (content != null)
            {
                if (content.TryGetComponent(out Bonus bonus))
                {
                    _firePower.AddFirePower(1);
                    bonus.ChangePositionBonus();                    
                }
                if (content.TryGetComponent(out Fire fire))
                {
                    _endGame.FinishGame();
                    targetPoint = null;
                    return false;
                }
            }

            targetPoint = point;
            return true;
        }
        else
        {
            _endGame.FinishGame();           
        }

        targetPoint = null;
        return false;
    }
}
