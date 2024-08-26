using System.Collections.Generic;
using UnityEngine;

public class BuildEdging : MonoBehaviour
{
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
        string json = PlayerPrefs.GetString("LevelData");
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        _spawnPointPixels = levelConfig.SpawnPointsPixels;
        _spawnPointsEdging = levelConfig.SpawnPointsEdging;
        _pointsColors = levelConfig.ColorPixels;

        foreach (var pointEdging in _spawnPointsEdging)
        {
            SpawnCube(pointEdging);
        }

        for(int i = 0; i < _spawnPointPixels.Count; i++)
        {
            SpawnPixelPoint(_spawnPointPixels[i], _pointsColors[i]);
        }
    }

    private void SpawnCube(Vector3 spawnPosition)
    {
        Instantiate(_blackCube, spawnPosition, Quaternion.identity, _parentEdging);
    }

    private void SpawnPixelPoint(Vector3 spawnPosition, string color)
    {
        foreach (PixelPoint pixelPoint in _pixelPointPrefabs)
        {
            if (pixelPoint.GetColor() == color)
                Instantiate(pixelPoint, spawnPosition, Quaternion.identity, _parentPixelPoints);
        }
    }
}
