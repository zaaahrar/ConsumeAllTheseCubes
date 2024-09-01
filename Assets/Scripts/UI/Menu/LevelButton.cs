using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private const string LevelDataKey = "LevelData";

    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private LevelSelectMenu _levelSelectMenu;
    [SerializeField] private GameObject[] _stars;

    [Header("LevelConfig")]
    [SerializeField] private int _countCubes;
    [SerializeField] private List<Vector3> _spawnPoints;
    [SerializeField] private List<string> _colorCubes;
    [SerializeField] List<Vector3> _spawnPointsPixels;
    [SerializeField] List<Vector3> _spawnPointsEdging;
    [SerializeField] List<string> _colorPixels;
    [SerializeField] private int _time;

    private int _level = 1;
    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    public void OnClick()
    {
        WriteConfig();
        _levelSelectMenu.StartLevel(_level);
    }

    [ContextMenu("LoadCubeConfig")]
    public void WriteCubeConfig()
    {
        string json = PlayerPrefs.GetString("CubeConfig");
        SpawnCubeConfig ess = JsonUtility.FromJson<SpawnCubeConfig>(json);
        _spawnPoints = ess.Position;
        _colorCubes = ess.Color;
    }

    [ContextMenu("LoadPixelArtConfig")]
    public void LoadPixelArtConfig()
    {
        string json = PlayerPrefs.GetString("PixelArtConfig");
        PixelArtConfig pixelArtCfg = JsonUtility.FromJson<PixelArtConfig>(json);
        _spawnPointsPixels = pixelArtCfg.SpawnPointsPixels;
        _spawnPointsEdging = pixelArtCfg.SpawnPointsEdging;
        _colorPixels = pixelArtCfg.ColorPixels;
    }

    public void Setup(int level, bool isUnlock)
    {
        _level = level;
        _levelText.text = _level.ToString();

        if (isUnlock)
        {
            _lockPanel.SetActive(false);
            _button.enabled = true;
            _levelText.gameObject.SetActive(true);
            DisplayStars();
        }
        else
        {
            _lockPanel.SetActive(true);
            _button.enabled = false;
            _levelText.gameObject.SetActive(false);
        }
    }

    public void HideStars()
    {
        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].gameObject.SetActive(false);
        }
    }

    private void WriteConfig()
    {
        LevelConfigTemplate levelConfig = new LevelConfigTemplate();
        levelConfig.LevelNumber = _level;
        levelConfig.CountCubes = _countCubes;
        levelConfig.SpawnPoints = _spawnPoints;
        levelConfig.Colors = _colorCubes;
        levelConfig.Time = _time;
        levelConfig.SpawnPointsPixels = _spawnPointsPixels;
        levelConfig.SpawnPointsEdging = _spawnPointsEdging;
        levelConfig.ColorPixels = _colorPixels;

        string levelConfigJson = JsonUtility.ToJson(levelConfig);
        PlayerPrefs.SetString(LevelDataKey, levelConfigJson);
    }

    private void DisplayStars()
    {
        int starsCount = PlayerPrefs.GetInt("StarsLevel" + _level);

        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].gameObject.SetActive(true);
        }
    }
}
