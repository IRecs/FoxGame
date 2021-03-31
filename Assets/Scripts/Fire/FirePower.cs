using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePower : MonoBehaviour
{
    private float _firePower = 1000;
    private float _gain = 0.1f;

    public float GetFirePower()
    {
        return _firePower * _gain;
    }

}
