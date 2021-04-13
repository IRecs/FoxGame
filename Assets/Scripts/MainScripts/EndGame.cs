using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneСontrol;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _endPanelAnimator;
    [SerializeField] private float _waitingTime;

    public void FinishGame()
    {
        _playerAnimator.SetBool(AnimatorModelController.Params.Die, true);
        _endPanelAnimator.gameObject.SetActive(true);
        _endPanelAnimator.SetBool(AnimatorEndPanelController.Params.End, true);
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(_waitingTime);
        _sceneСontrol.RestartScene();
    }
}
