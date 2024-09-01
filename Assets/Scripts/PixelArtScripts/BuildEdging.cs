using System.Collections.Generic;
using UnityEngine;

public class BuildEdging : MonoBehaviour
{
    private const string LevelDataKey = "LevelData";

    [SerializeField] private GameObject _blackCube;
    [SerializeField] private PixelPoint[] _pixelPointPrefabs;
    [SerializeField] private Transform _parentEdging;
    [SerializeField] private Transform _parentPixelPoints;

    [Header("EdgingSettings")]
    [SerializeField] private List<Vector3> _spawnPointPixels;
    [SerializeField] private List<Vector3> _spawnPointsEdging;
    [SerializeField] private List<string> _pointsColors;

    private void Awake()
    {
        Initialize();
        SpawnCube();
        SpawnPixelPoint();
    }

    private void Initialize()
    {
        string json = PlayerPrefs.GetString(LevelDataKey);
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        _spawnPointPixels = levelConfig.SpawnPointsPixels;
        _spawnPointsEdging = levelConfig.SpawnPointsEdging;
        _pointsColors = levelConfig.ColorPixels;
    }

    private void SpawnCube()
    {
        foreach (var pointEdging in _spawnPointsEdging)
        {
            Instantiate(_blackCube, pointEdging, Quaternion.identity, _parentEdging);
        }
    }

    private void SpawnPixelPoint()
    {
        for (int i = 0; i < _spawnPointPixels.Count; i++)
        {
            foreach (PixelPoint pixelPoint in _pixelPointPrefabs)
            {
                if (pixelPoint.GetColor() == _pointsColors[i])
                    Instantiate(pixelPoint, _spawnPointPixels[i], Quaternion.identity, _parentPixelPoints);
            }
        }
    }
}
