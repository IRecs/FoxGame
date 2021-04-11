using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timeToWait = 1;
    private Field _field;
    private float _heightCorrection = 1f;

    public void SetField(Field field)
    {
        _field = field;
        ChangePositionBonus();
    }

    public void ChangePositionBonus()
    {
        if (_field.FindingFreePoint(out Point freePoint))
        {
            _audioSource.Play();
            Vector3 position = freePoint.GetPointPosition();
            position.y += _heightCorrection;
            transform.position = position;
            freePoint.SetPointContent(gameObject);
        }
    }
}
