using UnityEngine;

public class ShopControler : MonoBehaviour
{
    [SerializeField] private SpeedImprovement _speedImprovement;
    [SerializeField] private SpeedImprovementView _speedImprovementView;
    [SerializeField] private MoneyImprovement _moneyImprovement;
    [SerializeField] private MoneyImprovementView _moneyImprovementView;
    [SerializeField] private TimeImprovement _timeImprovement;
    [SerializeField] private TimeImprovementView _timeImprovementView;
    [SerializeField] private ShopView _shopView;

    [SerializeField] private int _money;

    private void Start()
    {
        _speedImprovement.Initialize();
        _timeImprovement.Initialize();
        _moneyImprovement.Initialize();

        _speedImprovementView.UpdateUI(_speedImprovement.Level, _speedImprovement.MaxLevel, _speedImprovement.GetCost());
        _moneyImprovementView.UpdateUI(_moneyImprovement.Level, _moneyImprovement.MaxLevel, _moneyImprovement.GetCost());
        _timeImprovementView.UpdateUI(_timeImprovement.Level, _timeImprovement.MaxLevel, _timeImprovement.GetCost());
    }

    private void OnEnable()
    {
        _money = PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentMoneyKey);
        _shopView.UpdateMoney(_money);
        _speedImprovementView.OnButtonClicked += TryBuyImprovementSpeed;
        _moneyImprovementView.OnButtonClicked += TryBuyImprovementMoney;
        _timeImprovementView.OnButtonClicked += TryBuyImprovementTime;
    }

    private void OnDisable()
    {
        _speedImprovementView.OnButtonClicked -= TryBuyImprovementSpeed;
        _moneyImprovementView.OnButtonClicked -= TryBuyImprovementMoney;
        _timeImprovementView.OnButtonClicked -= TryBuyImprovementTime;
    }

    public void TryBuyImprovement(Improvement improvement, ImprovementView view, string levelKey)
    {
        if (improvement.Level < improvement.MaxLevel && CanImprove(improvement.GetCost()))
        {
            DeductCost(improvement.GetCost());
            improvement.AddLevel();
            PlayerPrefs.SetInt(levelKey, improvement.Level);
            view.UpdateUI(improvement.Level, improvement.MaxLevel, improvement.GetCost());
        }
    }

    private void TryBuyImprovementSpeed() => TryBuyImprovement(_speedImprovement, _speedImprovementView,
        PlayerPrefsKeys.SpeedLevelKey);

    private void TryBuyImprovementMoney() => TryBuyImprovement(_moneyImprovement, _moneyImprovementView,
        PlayerPrefsKeys.MoneyPerCubeLevelKey);

    private void TryBuyImprovementTime() => TryBuyImprovement(_timeImprovement, _timeImprovementView,
        PlayerPrefsKeys.ExtraTimeLevelKey);

    private void DeductCost(int cost)
    {
        _money -= cost;
        _shopView.UpdateMoney(_money);
        PlayerPrefs.SetInt(PlayerPrefsKeys.CurrentMoneyKey, _money);
    }

    private bool CanImprove(int cost)
    {
        return _money >= cost ? true : false;
    }
}
