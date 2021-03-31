using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _losePanel;
    private int _firePower;
    private int _score;

    public event UnityAction<int> ChangedFirePower;
    public int FirePower => _firePower;

    private void Start()
    {
        ChangedFirePower?.Invoke(_firePower);
    }

    public void AddFirePower(int power)
    {
        if (power > 0)
        {
            _score += power;
            _firePower = _score/4;
        }
        ChangedFirePower?.Invoke(_score);
    }

    public void Die()
    {
        /*PlayerPrefs.SetInt("OllScore", PlayerPrefs.GetInt("OllScore", 0) + _score);
        PlayerPrefs.SetInt("LastScore", _score);
        if(_score > PlayerPrefs.GetInt("TopScore", 0))
            PlayerPrefs.SetInt("TopScore", _score);
        _mainCamera.GetComponent<Menu>().RestartGame();*/
    }
}
