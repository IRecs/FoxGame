using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSource;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private List<Sprite> _images;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Mute"))
            PlayerPrefs.SetInt("Mute", 1);

        CheckMute();

    }

    private void CheckMute()
    {
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            for (int i = 0; i < _audioSource.Count; i++)
            {
                _audioSource[i].enabled = false;
            }
            _buttonImage.sprite = _images[0];
        }
        else if (PlayerPrefs.GetInt("Mute") == 1)
        {
            for (int i = 0; i < _audioSource.Count; i++)
            {
                _audioSource[i].enabled = true;
            }
            _buttonImage.sprite = _images[1];
        }
    }

    public void RefreshMute()
    {
        if(PlayerPrefs.GetInt("Mute") == 1)
            PlayerPrefs.SetInt("Mute", 0);
        else if (PlayerPrefs.GetInt("Mute") == 0)
            PlayerPrefs.SetInt("Mute", 1);
        CheckMute();
    }
}
