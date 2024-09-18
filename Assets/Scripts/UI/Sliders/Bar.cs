using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _maxDelta;

    public Slider Slider => _slider;
    public float MaxDelta => _maxDelta;

    private void Awake() => Slider.value = 0;

    public abstract void OnSliderValueChanged(float value);

    public abstract IEnumerator ChangeProgress(float targetProgress);
}
