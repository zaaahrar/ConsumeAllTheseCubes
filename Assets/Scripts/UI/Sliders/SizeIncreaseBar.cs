using System.Collections;
using UnityEngine;

public class SizeIncreaseBar : Bar
{
    [SerializeField] private IncreasingFunnel _increasingFunnel;

    private Coroutine _currentCoroutine;

    private void Start() => Slider.maxValue = _increasingFunnel.NumberCubes;

    private void OnEnable() => _increasingFunnel.IncreasingSliderUpdateEvent += OnSliderValueChanged;

    private void OnDisable() => _increasingFunnel.IncreasingSliderUpdateEvent -= OnSliderValueChanged;

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

            if (_increasingFunnel.IsAssembled == true)
            {
                Slider.value = 0;
                _increasingFunnel.MakeNotAssemled();
                Slider.maxValue = _increasingFunnel.NumberCubes;
            }

            yield return null;
        }
    }
}
