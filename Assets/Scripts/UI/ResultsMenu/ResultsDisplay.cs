using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{
    [SerializeField] private List<AnimationStars> _stars;
    [SerializeField] private PixelArtBuilder _pixelArtBuilder;
    [SerializeField] private TMP_Text _moneyPerLevelText;
    [SerializeField] private TMP_Text _indicatorText;
    [SerializeField] private TMP_Text _cubesCollectText;
    [SerializeField] private TMP_Text _levelText;

    private void OnEnable() => _pixelArtBuilder.UpdateResults += ShowResults;

    private void OnDisable() => _pixelArtBuilder.UpdateResults -= ShowResults;

    private void ShowResults(float buildCubes, float maxCubesCount)
    {
        string json = PlayerPrefs.GetString("LevelData");
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        float moneyPerLevel = PlayerPrefs.GetFloat("MoneyPerLevel");

        _levelText.text = $"УРОВЕНЬ {levelConfig.LevelNumber}";
        _moneyPerLevelText.text = moneyPerLevel.ToString();
        _cubesCollectText.text = $"{buildCubes}/{maxCubesCount}";

        DisplayStars(maxCubesCount, buildCubes);
    }

    private void DisplayStars(float maxCubesCount, float buildCubes)
    {
        int starsCount = GetNumberStars(maxCubesCount, buildCubes);
        Debug.Log(starsCount + "stars");
        Debug.Log(maxCubesCount + " " + buildCubes);

        for (int i = 0; i<starsCount; i++)
        {
            _stars[i].gameObject.SetActive(true);
        }

        DisplayIndicatorText(starsCount);
    }

    private void DisplayIndicatorText(float numberStars)
    {

        if (numberStars == 1)
            _indicatorText.text = "Неплохо!";
        else if (numberStars == 2)
            _indicatorText.text = "Победа!";
        else if (numberStars == 3)
            _indicatorText.text = "Триумф!";
        else
            _indicatorText.text = "Не унывай!";
    }

    private int GetNumberStars(float maxCubesCount, float buildCubes)
    {
        float fiftyPercent = 0.5f;
        float seventyFivePercent = 0.75f;
        float oneHundredPercent = 1;
        float progress = (float)buildCubes / maxCubesCount;

        if (progress >= oneHundredPercent)
        {
            return 3;
        }
        else if (progress >= seventyFivePercent)
        {
            return 2; 
        }
        else if (progress >= fiftyPercent)
        {
            return 1;
        }
        else
        {
            return 0; 
        }
    }
}
