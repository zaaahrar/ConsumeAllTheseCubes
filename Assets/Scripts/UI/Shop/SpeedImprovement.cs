using UnityEngine;

public class SpeedImprovement : Improvement
{
    public void Initialize() => GetLevel(PlayerPrefs.GetInt(PlayerPrefsKeys.SpeedLevelKey));
}
