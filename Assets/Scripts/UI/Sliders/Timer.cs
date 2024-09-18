using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int Second = 1;

    [SerializeField] private SceneChanger _sceneChanger;

    public event Action<float> TimerSliderUpdateEvent;

    private WaitForSeconds _delaySecond;
    private int _timerDuration;

    public int TimerDuration => _timerDuration;

    private void Start()
    {
        _delaySecond = new WaitForSeconds(Second);
        StartCoroutine(StartTimer());
    }

    public void ChangeTime(int value) => _timerDuration = value;

    private IEnumerator StartTimer()
    {
        for(int i = _timerDuration; i >= 0; i--)
        {
            TimerSliderUpdateEvent?.Invoke(i);
            yield return _delaySecond;
        }

        _sceneChanger.LoadPixelArtScene();
    }
}
