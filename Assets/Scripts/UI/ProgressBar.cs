using System.Collections;
using TMPro;
using UnityEngine;

public class ProgressBar : Bar
{
    private const int AuxiliaryPercentage = 100;

    [SerializeField] private CubeCounter _cubeCounter;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private TMP_Text _progressText;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        Slider.maxValue = _cubeCounter.TotalCubesCount;
        UpdateText();
    }

    private void OnEnable() => _cubeCounter.SliderUpdateEvent += OnSliderValueChanged;

    private void OnDisable() => _cubeCounter.SliderUpdateEvent -= OnSliderValueChanged;

    public override void OnSliderValueChanged(float value)
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeProgress(value));
    }

    public override IEnumerator ChangeProgress(float targetProgress)
    {
        while (Slider.value != targetProgress)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, targetProgress, MaxDelta * Time.deltaTime);
            CheckCompletion();
            UpdateText();
            yield return null;
        }
    }

    private void UpdateText() => _progressText.text = Mathf.RoundToInt((Slider.value * AuxiliaryPercentage) / _cubeCounter.TotalCubesCount) + "%";

    private void CheckCompletion()
    {
        if (Slider.value == Slider.maxValue)
            _sceneChanger.LoadPixelArtScene();
    }
}
