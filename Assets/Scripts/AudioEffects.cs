using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    private const int DefaultValue = 1;
    private const string EffectsVolumeKey = "EffectsVolume";

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundKnock;
    [SerializeField] private AudioClip _soundCollectCube;
    [SerializeField] private AudioClip _soundCubeBuilding;

    private void Start() => _audioSource.volume = PlayerPrefs.GetFloat(EffectsVolumeKey, DefaultValue);

    public void PlaySoundKnock()
    {
        _audioSource.clip = _soundKnock;
        _audioSource.Play();
    }

    public void PlaySoundCubeCollect()
    {
        _audioSource.clip = _soundCollectCube;

        if (_audioSource.isPlaying)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = _audioSource.clip;
            newSource.Play();
            Destroy(newSource, _audioSource.clip.length);
        }
        else
        {
            _audioSource.Play();
        }
    }
    public void PlaySoundCubeBuilding()
    {
        _audioSource.clip = _soundCubeBuilding;

        if (_audioSource.isPlaying)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = _audioSource.clip;
            newSource.Play();
            Destroy(newSource, _audioSource.clip.length);
        }
        else
        {
            _audioSource.Play();
        }
    }
}
