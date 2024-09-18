using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private float _durationAnimate;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    [SerializeField] private Button _openMenuButton;
    [SerializeField] private Button _closeMenuButton;

    [SerializeField] private Button _exitToMenuButton;
    [SerializeField] private Button _resetLevelButton;

    public event Action OnExitingMenu;
    public event Action OnResetingLevel;

    private float _liftingPositionY = -135;
    private float _loveringPositionY = 865;

    private void OnEnable()
    {
        _openMenuButton.onClick.AddListener(OpenPanel);
        _closeMenuButton.onClick.AddListener(ClosePanel);
        _exitToMenuButton.onClick.AddListener(ExitToMenu);
        _resetLevelButton.onClick.AddListener(ResetLevel);
    }

    private void OnDisable()
    {
        _openMenuButton.onClick.RemoveListener(OpenPanel);
        _closeMenuButton.onClick.RemoveListener(ClosePanel);
        _exitToMenuButton.onClick.RemoveListener(ExitToMenu);
        _resetLevelButton.onClick.RemoveListener(ResetLevel);
    }

    public void ExitToMenu()
    {
        _audioFeedback.PlaySoundClick();
        OnExitingMenu?.Invoke();
    }

    public void ResetLevel()
    {
        _audioFeedback.PlaySoundClick();
        OnResetingLevel?.Invoke();
    }

    private void OpenPanel() => StartCoroutine(OpeningPanel());

    private void ClosePanel() => StartCoroutine(ClosingPanel());

    private IEnumerator ClosingPanel()
    {
        Time.timeScale = 1;
        _audioFeedback.PlaySoundClick();
        _pausePanel.transform.DOLocalMoveY(_loveringPositionY, _durationAnimate).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        yield return new WaitForSeconds(_durationAnimate);
        _pausePanel.SetActive(false);
    }

    private IEnumerator OpeningPanel()
    {
        _pausePanel.SetActive(true);
        _audioFeedback.PlaySoundPanelsActive();
        _pausePanel.transform.DOLocalMoveY(_liftingPositionY, _durationAnimate).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        yield return new WaitForSeconds(_durationAnimate);
        Time.timeScale = 0;
    }
}
