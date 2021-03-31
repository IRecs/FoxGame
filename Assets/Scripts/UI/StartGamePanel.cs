using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGamePanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _elements;

    public void OpenElements()
    {
        for (int i = 0; i < _elements.Count; i++)
        {
            _elements[i].SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
