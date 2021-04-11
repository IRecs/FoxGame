using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirePool : ObjectPool
{
    protected void AddFire(Fire fire, Point point)
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
