using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    private const float MaxDelta = 20f;

    [SerializeField] private MoneyHandler _moneyHandler;
    [SerializeField] private TMP_Text _moneyText;

    private float _imaginaryMoney;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _imaginaryMoney = _moneyHandler.Money;
        _moneyText.text = _imaginaryMoney.ToString();
    }

    private void OnEnable() => _moneyHandler.MoneyUpdateAction += RestartProgressMoney;

    private void OnDisable() => _moneyHandler.MoneyUpdateAction -= RestartProgressMoney;

    public void RestartProgressMoney(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(UpdateMoney(value));
    }

    private IEnumerator UpdateMoney(float targetProgress)
    {
        while (_imaginaryMoney != targetProgress)
        {
            _imaginaryMoney = Mathf.MoveTowards(_imaginaryMoney, targetProgress, MaxDelta * Time.deltaTime);
            _moneyText.text = Mathf.RoundToInt(_imaginaryMoney).ToString();
            yield return null;
        }
    }
}
