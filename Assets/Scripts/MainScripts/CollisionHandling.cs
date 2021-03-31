using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EndGame))]

public class CollisionHandling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private EndGame _endGame;
    private Field _field;
    private BonusPositionsControl _bonusPositionsControl;
    private FireControl _fireControl;
    
    private void Start()
    {
        _endGame = GetComponent<EndGame>();
    }

    public void SetField(Field field)
    {
        _field = field;
    }

    public void SetFireControl(FireControl fireControl)
    {
        _fireControl = fireControl;
    }

    public void SetBonusControl(BonusPositionsControl bonusPositionsControl)
    {
        _bonusPositionsControl = bonusPositionsControl;
    }

    public bool DefineTargetPoint(Vector2Int targetPointNumber, out Vector3 targetPosition)
    {
        if (_field.GetPointContent(targetPointNumber, out GameObject content))
        {
            if (content != null)
            {
                if (content.TryGetComponent(out Bonus bonus))
                {
                    _fireControl.AddFirePower(1);
                    _audioSource.Play();
                    _bonusPositionsControl.ChangePositionBonus();                    
                }
                if (content.TryGetComponent(out Fire fire))
                {
                    _endGame.FinishGame();
                    targetPosition = Vector3.zero;
                    return false;
                }
            }
            _field.GetPointPosition(targetPointNumber, out targetPosition);
            return true;
        }
        else
        {
            _endGame.FinishGame();           
        }
        targetPosition = Vector3.zero;
        return false;
    }
}
