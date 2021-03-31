using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    public void OpenPanel()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
