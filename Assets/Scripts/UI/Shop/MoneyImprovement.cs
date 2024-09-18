using UnityEngine;

public class MoneyImprovement : Improvement
{
    public void Initialize() => GetLevel(PlayerPrefs.GetInt(PlayerPrefsKeys.MoneyPerCubeLevelKey));
}
