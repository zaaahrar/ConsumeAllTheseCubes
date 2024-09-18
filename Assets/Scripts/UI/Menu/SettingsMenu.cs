using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private const int DefaultValue = 1;

    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    [Header("Buttons")]
    [SerializeField] private Button _applySettingsButton;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    [Header("Sliders")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundEffectsSlider;
    [SerializeField] private Slider _soundUISlider;

    [Header("AudioSurces")]
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffects;
    [SerializeField] private AudioSource _audioSourceUI;

    private void Awake()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.MusicVolumeKey, DefaultValue);
        _soundEffectsSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.EffectsVolumeKey, DefaultValue);
        _soundUISlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.UIVolumeKey, DefaultValue);
        ApplySettings();
    }

    private void OnEnable()
    {
        _applySettingsButton.onClick.AddListener(ApplySettings);
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _applySettingsButton.onClick.RemoveListener(ApplySettings);
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
    }

    public void ApplySettings()
    {
        _audioSourceMusic.volume = _musicSlider.value;
        PlayerPrefs.SetFloat(PlayerPrefsKeys.MusicVolumeKey, _musicSlider.value);
        _audioSourceEffects.volume = _soundEffectsSlider.value;
        PlayerPrefs.SetFloat(PlayerPrefsKeys.EffectsVolumeKey, _soundEffectsSlider.value);
        _audioSourceUI.volume = _soundUISlider.value;
        PlayerPrefs.SetFloat(PlayerPrefsKeys.UIVolumeKey, _soundUISlider.value);

        _audioFeedback.PlaySoundClick();
    }

    private void Open()
    {
        _audioFeedback.PlaySoundClick();
        _panelSettings.SetActive(true);
    }

    private void Close()
    {
        _audioFeedback.PlaySoundClick();
        _panelSettings.SetActive(false);
    }
}
