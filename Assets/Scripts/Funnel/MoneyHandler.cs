using System;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private float _money;

    public event Action<float> MoneyUpdateAction;

    private float _moneyPerLevel;

    public float Money => _money;

    private void Awake() => ResetMoneyPerLevel();

    public void AddMoney(float money)
    {
        _money += money;
        PlayerPrefs.SetFloat("Money", _money);
        _moneyPerLevel += money;
        PlayerPrefs.SetFloat("MoneyPerLevel", _moneyPerLevel);
        MoneyUpdateAction?.Invoke(_money);
    }

    public void ResetMoneyPerLevel()
    {
        _moneyPerLevel = 0;
        PlayerPrefs.SetFloat("MoneyPerLevel", _moneyPerLevel);
    }
}
