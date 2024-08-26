using System.Collections;
using TMPro;
using UnityEngine;

public class PixelArtBuildingSlider : Bar
{
    private const int AuxiliaryPercentage = 100;

    [SerializeField] private PixelArtBuilder _pixelArtBuilder;
    [SerializeField] private TMP_Text _progressText;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        Slider.maxValue = _pixelArtBuilder.MaxCubesCount;
        UpdateText();
    }

    private void OnEnable() => _pixelArtBuilder.UpdateSliderAction += OnSliderValueChanged;

    private void OnDisable() => _pixelArtBuilder.UpdateSliderAction -= OnSliderValueChanged;

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
            UpdateText();
            yield return null;
        }
    }

    private void UpdateText() => _progressText.text = Mathf.RoundToInt((Slider.value * AuxiliaryPercentage) / _pixelArtBuilder.MaxCubesCount) + "%";
}
