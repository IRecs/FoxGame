using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;

    private AudioSource _audio;
    private int _currentClipNumber = 0;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        StartCoroutine(PlayerAudio());
    }

    private IEnumerator PlayerAudio()
    {
        int tempClipNumber = _currentClipNumber;

        while (tempClipNumber == _currentClipNumber)
            tempClipNumber = Random.Range(0, _clips.Count);

        _currentClipNumber = tempClipNumber;
        _audio.clip = _clips[_currentClipNumber];
        _audio.Play();

        yield return new WaitForSeconds(_audio.clip.length);
        
        StartCoroutine(PlayerAudio());

    }
}
