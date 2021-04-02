using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPositionsControl : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timeToWait = 1;
    private Field _field;
    private Bonus _bonus;
    private float _heightCorrection = 1f;

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
        if(_field.FindingFreePoint(out Point freePoint))
        {
            _audioSource.Play();
            Vector3 position = freePoint.GetPointPosition();
            position.y += _heightCorrection;
            _bonus.transform.position = position;
            freePoint.SetPointContent(_bonus.gameObject);
        }        
    }
}
