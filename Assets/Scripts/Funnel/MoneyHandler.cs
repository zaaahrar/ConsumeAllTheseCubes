using System;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private int _money;

    public event Action<float> MoneyUpdateAction;

    private int _moneyPerLevel;

    public int Money => _money;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.CurrentMoneyKey)) 
            _money = PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentMoneyKey);
    
        ResetMoneyPerLevel();
    }

    public void AddMoney(int money)
    {
        _money += money;
        PlayerPrefs.SetInt(PlayerPrefsKeys.CurrentMoneyKey, _money);
        _moneyPerLevel += money;
        PlayerPrefs.SetInt(PlayerPrefsKeys.MoneyPerLevelKey, _moneyPerLevel);
        MoneyUpdateAction?.Invoke(_money);
    }

    public void ResetMoneyPerLevel()
    {
        _moneyPerLevel = 0;
        PlayerPrefs.SetInt(PlayerPrefsKeys.MoneyPerLevelKey, _moneyPerLevel);
    }
}
