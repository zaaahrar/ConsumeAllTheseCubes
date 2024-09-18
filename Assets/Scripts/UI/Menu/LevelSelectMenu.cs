using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    private const int One = 1;

    [SerializeField] private Canvas _buttonsParent;

    [SerializeField] private int _totalLevel = 0;
    [SerializeField] private int _unLockedLevel = 1;

    private LevelButton[] _levelButtons;

    private void Awake() => _levelButtons = _buttonsParent.GetComponentsInChildren<LevelButton>();

    private void Start() => CheckUnlockedLevels();

    private void CheckUnlockedLevels()
    {
        for (int i = 1; i < _levelButtons.Length + 1; i++)
        {
            bool isPassed = PlayerPrefs.GetInt(PlayerPrefsKeys.LevelProgressKey + i) == One;

            if (isPassed)
                _unLockedLevel++;
        }

        RefreshButtons();
    }

    private void RefreshButtons()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            int level = i + One;

            if (level <= _totalLevel)
            {
                _levelButtons[i].Setup(level, level <= _unLockedLevel);
            }
        }
    }
}
