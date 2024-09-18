using UnityEngine;
using TMPro;
using System.Collections;

public class TimerBar : Bar
{
    private const int SecondInMinute = 60;

    [SerializeField] private Timer _timer;
    [SerializeField] private TMP_Text _timerText;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        Slider.maxValue = _timer.TimerDuration;
        Slider.value = _timer.TimerDuration;
        UpdateText(_timer.TimerDuration);
    }

    private void OnEnable() => _timer.TimerSliderUpdateEvent += OnSliderValueChanged;

    private void OnDisable() => _timer.TimerSliderUpdateEvent -= OnSliderValueChanged;

    public override void OnSliderValueChanged(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeProgress(value));
    }

    public override IEnumerator ChangeProgress(float targetProgress)
    {
        while (Slider.value != targetProgress)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, targetProgress, MaxDelta * Time.deltaTime);
            UpdateText(targetProgress);

            yield return null;
        }
    }

    private void UpdateText(float duration)
    {
        int maxNumberSecons = 9;

        int minutes = (int)duration / SecondInMinute;
        int seconds = (int)duration % SecondInMinute;

        if (seconds > maxNumberSecons)
            _timerText.text = $"{minutes}:{seconds}";
        else
            _timerText.text = $"{minutes}:0{seconds}";
    }
}
