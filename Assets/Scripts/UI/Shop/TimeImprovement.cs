using UnityEngine;

public class TimeImprovement : Improvement
{
    public void Initialize() => GetLevel(PlayerPrefs.GetInt(PlayerPrefsKeys.ExtraTimeLevelKey));
}
