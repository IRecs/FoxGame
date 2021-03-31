using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _topScore;
    [SerializeField] private TMP_Text _lastScore;

    private void OnEnable()
    {
        RefreshLastScore();
        RefreshTopScore();
    }

    private void RefreshTopScore()
    {
        int topScore;

        if (PlayerPrefs.HasKey("TopScore"))
        { 
            if(PlayerPrefs.GetInt("TopScore") < PlayerPrefs.GetInt("LastScore"))
                PlayerPrefs.SetInt("TopScore", PlayerPrefs.GetInt("LastScore"));
        }
        else
            PlayerPrefs.SetInt("TopScore", PlayerPrefs.GetInt("LastScore"));

        topScore = PlayerPrefs.GetInt("TopScore", 0);
        _topScore.text = topScore.ToString();
    }

    private void RefreshLastScore()
    {
        int lastScore;

        if (!PlayerPrefs.HasKey("LastScore"))
            PlayerPrefs.SetInt("LastScore", 0);

        lastScore = PlayerPrefs.GetInt("LastScore");
        _lastScore.text = lastScore.ToString();
    }
}
