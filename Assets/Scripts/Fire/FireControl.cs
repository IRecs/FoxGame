using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    private Field _field;
    private float _firePower = 0;
    private float _gain = 0.1f;

    public float GetFirePower()
    {
        return _firePower * _gain;
    }

    public void AddFirePower(float power)
    {
        _firePower += power;
        _score.text = Mathf.CeilToInt(_firePower).ToString();
        PlayerPrefs.SetInt("LastScore", Mathf.CeilToInt(_firePower));
    }

    public void SetField(Field field)
    {
        _field = field;
    }

    public void SetFire(Fire fire, Point point)
    {
        StartCoroutine(CombustionFire(fire, point));
    }

    private IEnumerator CombustionFire(Fire fire, Point point)
    {
        float time = fire.GetFirePower();
        yield return new WaitForSeconds(time);
        fire.gameObject.SetActive(false);
        point.SetPointContent(null);
    }
}
