using UnityEngine;

public class ResultsMenu : MonoBehaviour
{
    [SerializeField] private PixelArtBuilder _pixelArtBuilder;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private ResultsMenuView _menuView;

    private void OnEnable()
    {
        _pixelArtBuilder.UpdateResults += ShowResults;
        _menuView.OnOpeningMenu += ExitMenu;
        _menuView.OnResetingLevel += ResetLevel;
    }

    private void OnDisable()
    {
        _pixelArtBuilder.UpdateResults -= ShowResults;
        _menuView.OnOpeningMenu -= ExitMenu;
        _menuView.OnResetingLevel -= ResetLevel;
    }

    private void ShowResults(int assembledCubes, int maxCubesCount, int level)
    {
        int moneyPerLevel = PlayerPrefs.GetInt(PlayerPrefsKeys.MoneyPerLevelKey);
        _menuView.Open();
        _menuView.UpdateText(level, moneyPerLevel, assembledCubes, maxCubesCount);
        int starsCount = GetNumberStars(maxCubesCount, assembledCubes);
        _menuView.ViewStars(starsCount);
        _menuView.DisplayIndicatorText(starsCount);
        SaveStars(starsCount, level);
    }

    private int GetNumberStars(float maxCubesCount, float assembledCubes)
    {
        float progress = (float)assembledCubes / maxCubesCount;

        if (progress >= 1)
            return 3;
        else if (progress >= 0.75f)
            return 2;
        else if (progress >= 0.5f)
            return 1;
        else
            return 0;
    }

    private void SaveStars(int countStars, int level)
    {
        int previousStars = 0;

        if (PlayerPrefs.HasKey(PlayerPrefsKeys.StarsPerLevelKey + level))
           previousStars = PlayerPrefs.GetInt(PlayerPrefsKeys.StarsPerLevelKey + level);

        if(countStars > previousStars)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.StarsPerLevelKey + level, countStars);
            PlayerPrefs.Save();
        }
    }

    private void ExitMenu() => _sceneChanger.LoadMenuScene();

    private void ResetLevel() => _sceneChanger.LoadGameScene();
}
