using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundEffectsSlider;
    [SerializeField] private Slider _soundUISlider;

    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffects;
    [SerializeField] private AudioSource _audioSourceUI;

    private void Start()
    {
        _musicSlider.value = _audioSourceMusic.volume;
        _soundEffectsSlider.value = _audioSourceEffects.volume;
        _soundUISlider.value = _audioSourceUI.volume;
    }
}
