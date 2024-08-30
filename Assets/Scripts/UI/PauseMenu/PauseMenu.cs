using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private float _durationAnimate;

    private float _liftingPositionY = -135;
    private float _loveringPositionY = 865;

    private void OnDestroy()
    {
        _pausePanel.transform.DOKill();
    }

    public void OpenPanel() => StartCoroutine(OpeningPanel());

    public void ClosePanel() => StartCoroutine(ClosingPanel());

    public void ExitMenu()
    {
        Time.timeScale = 1;
        _sceneChanger.LoadMenuScene();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        _sceneChanger.LoadGameScene();
    }

    private IEnumerator ClosingPanel()
    {
        Time.timeScale = 1;
        _pausePanel.transform.DOLocalMoveY(_loveringPositionY, _durationAnimate);
        Debug.Log($"OpenPanel: {_loveringPositionY}, {_durationAnimate}");
        yield return new WaitForSeconds(_durationAnimate);
        _pausePanel.SetActive(false);
    }

    private IEnumerator OpeningPanel()
    {
        _pausePanel.SetActive(true);
        _pausePanel.transform.DOLocalMoveY(_liftingPositionY, _durationAnimate);
        Debug.Log($"ClosePanel: {_liftingPositionY}, {_durationAnimate}");
        yield return new WaitForSeconds(_durationAnimate);
        Time.timeScale = 0;
    }
}
