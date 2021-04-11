using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirePower : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
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


}
