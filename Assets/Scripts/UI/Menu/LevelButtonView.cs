using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonView : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private UIAudioFeedback _audioFeedback;
    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private Button _button;

    public event Action OnClickedButton;

    private void OnEnable() => _button.onClick.AddListener(ClickButton);

    private void OnDisable() => _button.onClick.RemoveListener(ClickButton);

    public void ClickButton()
    {
        _audioFeedback.PlaySoundClick();
        OnClickedButton?.Invoke();
        _sceneChanger.LoadGameScene();
    }

    public void Unlock()
    {
        _lockPanel.SetActive(false);
        _button.enabled = true;
        _levelText.gameObject.SetActive(true);
    }

    public void Lock()
    {
        _lockPanel.SetActive(true);
        _button.enabled = false;
        _levelText.gameObject.SetActive(false);
    }

    public void UpdateLevelText(int level) => _levelText.text = level.ToString();

    public void DisplayStars(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].gameObject.SetActive(true);
        }
    }
}
