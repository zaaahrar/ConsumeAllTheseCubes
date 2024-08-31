using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private const int DefaultValue = 1;
    private const string MusicVolumeKey = "MusicVolume";
    private const string EffectsVolumeKey = "EffectsVolume";
    private const string UIVolumeKey = "UIVolume";

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundEffectsSlider;
    [SerializeField] private Slider _soundUISlider;

    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffects;
    [SerializeField] private AudioSource _audioSourceUI;

    private void OnEnable()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, DefaultValue);
        _soundEffectsSlider.value = PlayerPrefs.GetFloat(EffectsVolumeKey, DefaultValue);
        _soundUISlider.value = PlayerPrefs.GetFloat(UIVolumeKey, DefaultValue); ;
    }

    public void ApplySettings()
    {
        _audioSourceMusic.volume = _musicSlider.value;
        PlayerPrefs.SetFloat(MusicVolumeKey, _musicSlider.value);
        _audioSourceEffects.volume = _soundEffectsSlider.value;
        PlayerPrefs.SetFloat(EffectsVolumeKey, _soundEffectsSlider.value);
        _audioSourceUI.volume = _soundUISlider.value;
        PlayerPrefs.SetFloat(UIVolumeKey, _soundUISlider.value);
    }
}
