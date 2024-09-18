using Lean.Localization;
using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultsMenuView : MonoBehaviour
{
    private const string LevelTextKey = "Уровень";

    [SerializeField] private UIAudioFeedback _audioFeedback;
    [SerializeField] private GameObject _resultsDisplay;
    [SerializeField] private Slider _pixelArtBuildSlider;

    [Header("Texts")]
    [SerializeField] private TMP_Text _moneyPerLevelText;
    [SerializeField] private TMP_Text _indicatorText;
    [SerializeField] private TMP_Text _cubesCollectText;
    [SerializeField] private TMP_Text _levelText;

    [Header("Buttons")]
    [SerializeField] private Button _resetLevelButton;
    [SerializeField] private Button _menuButton;

    [SerializeField] private List<AnimationStars> _stars;
    [SerializeField] private string[] _levelProgressIndicators;
    [SerializeField] private float _durationAnimate;

    public event Action OnResetingLevel;
    public event Action OnOpeningMenu;

    private float _finishPositionY = -125;

    private void OnEnable()
    {
        _resetLevelButton.onClick.AddListener(ResetLevel);
        _menuButton.onClick.AddListener(ExitMenu);
    }

    private void OnDisable()
    {
        _resetLevelButton.onClick.RemoveListener(ResetLevel);
        _menuButton.onClick.RemoveListener(ExitMenu);   
    }

    public void ResetLevel()
    {
        _audioFeedback.PlaySoundClick();
        OnResetingLevel?.Invoke();
    }

    public void ExitMenu()
    {
        _audioFeedback.PlaySoundClick();
        OnOpeningMenu.Invoke();
    }

    public void Open()
    {
        _audioFeedback.PlaySoundResultsPanelActive();
        _resultsDisplay.gameObject.SetActive(true);
        _pixelArtBuildSlider.gameObject.SetActive(false);
        _resultsDisplay.transform.DOLocalMoveY(_finishPositionY, _durationAnimate);
    }

    public void UpdateText(int levelNumber, int moneyPerLevel, int assembledCubes, int maxCubesCount)
    {
        _levelText.text = $"{LeanLocalization.GetTranslationText(LevelTextKey)} {levelNumber}";
        _moneyPerLevelText.text = moneyPerLevel.ToString();
        _cubesCollectText.text = $"{assembledCubes}/{maxCubesCount}";
    }

    public void ViewStars(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].gameObject.SetActive(true);
        }
    }

    public void DisplayIndicatorText(int numberStars) => _indicatorText.text = LeanLocalization.GetTranslationText(_levelProgressIndicators[numberStars]);
}
