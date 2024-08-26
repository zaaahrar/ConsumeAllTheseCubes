using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private PixelArtBuilder _pixelArtBuilder;
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private TMP_Text _moneyPerLevelText;
    [SerializeField] private TMP_Text _cubesCollectText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Slider _pixelArtBuildSlider;

    private void OnEnable() => _pixelArtBuilder.OpenFinishMenu += Open;

    private void OnDisable() => _pixelArtBuilder.OpenFinishMenu -= Open;

    private void Open()
    {
        string json = PlayerPrefs.GetString("LevelData");
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        _levelText.text = $"спнбемэ {levelConfig.LevelNumber}";
        _pixelArtBuildSlider.gameObject.SetActive(false);
        float moneyPerLevel = PlayerPrefs.GetFloat("MoneyPerLevel");
        _finishMenu.SetActive(true);
        _moneyPerLevelText.text = moneyPerLevel.ToString();
        _cubesCollectText.text = $"{_pixelArtBuilder.BuildCubes}/{_pixelArtBuilder.MaxCubesCount}";
    }

    private void Close()
    {

    }
}
