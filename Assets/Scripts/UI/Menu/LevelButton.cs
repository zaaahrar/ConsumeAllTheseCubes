using System;
using UnityEngine;
using Agava.YandexGames;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelButtonView _levelButtonView;

    private int _level = 1;

    private void OnEnable() => _levelButtonView.OnClickedButton += OnClick;

    private void OnDisable() => _levelButtonView.OnClickedButton -= OnClick;

    public void Setup(int level, bool isUnlock)
    {
        _level = level;
        _levelButtonView.UpdateLevelText(level);

        if (isUnlock)
        {
            _levelButtonView.Unlock();
            _levelButtonView.DisplayStars(PlayerPrefs.GetInt(PlayerPrefsKeys.StarsPerLevelKey + _level));
        }
        else
        {
            _levelButtonView.Lock();
        }
    }

    private void OnClick()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.CurrentLevelKey, _level);

#if UNITY_WEBGL && !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
    }
}
