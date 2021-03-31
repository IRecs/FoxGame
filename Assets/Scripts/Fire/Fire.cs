using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float _firePower = 0;

    public void SetFirePower(float firePower)
    {
        if(firePower >= 0)
            _firePower = firePower;
    }

    public float GetFirePower()
    {
       return _firePower;
    }
}
