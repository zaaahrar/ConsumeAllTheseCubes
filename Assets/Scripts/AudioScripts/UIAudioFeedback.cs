using UnityEngine;

public class UIAudioFeedback : MonoBehaviour
{
    private const int DefaultValue = 1;
    private const string UIVolumeKey = "UIVolume";

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundClick;
    [SerializeField] private AudioClip _resultsPanelAudio;
    [SerializeField] private AudioClip _panelsAudio;

    private void Start() => _audioSource.volume = PlayerPrefs.GetFloat(UIVolumeKey, DefaultValue);

    public void PlaySoundClick()
    {
        _audioSource.clip = _soundClick;
        _audioSource.Play();
    }

    public void PlaySoundResultsPanelActive()
    {
        _audioSource.clip = _resultsPanelAudio;
        _audioSource.Play();
    }

    public void PlaySoundPanelsActive()
    {
        _audioSource.clip = _panelsAudio;
        _audioSource.Play();
    }
}
