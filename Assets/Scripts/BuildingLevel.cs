using UnityEngine;

public class BuildingLevel : MonoBehaviour
{
    [SerializeField] private ImprovementsValue _improvementsConfig;
    [SerializeField] private LevelSettings[] _levels;
    [SerializeField] private Transform _parentCubes;
    [SerializeField] private Timer _timer;

    private void Awake()
    {
        int currentLevel = PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey);
        Instantiate(_levels[currentLevel - 1].LevelPrefab, _parentCubes);
        _timer.ChangeTime(_levels[currentLevel - 1].Time + GetExtraTime());
    }

    public int GetExtraTime()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.ExtraTimeLevelKey))
            return PlayerPrefs.GetInt(PlayerPrefsKeys.ExtraTimeLevelKey) * _improvementsConfig.TimeValue;
        else
            return 0;
    }
}
