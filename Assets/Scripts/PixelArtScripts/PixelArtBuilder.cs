using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using System;

public class PixelArtBuilder : MonoBehaviour
{
    private const int DevisorHalf = 2;
    private const int ValueLevelCompletion = 1;

    [Header("Spawners")]
    [SerializeField] private EffectsSpawner _effectsSpawner;
    [SerializeField] private CubesSpawner _cubesSpawner;

    [SerializeField] private LevelSettings[] _levels;
    [SerializeField] private AudioEffects _audioEffects;
    [SerializeField] private Transform _parentPoints; 
    [SerializeField] private float _delaySpawnCubes;

    public event Action<float> UpdateSliderAction;
    public event Action<int, int, int> UpdateResults;

    private Transform _parentSubstrate;

    private WaitForSeconds _delaySpawn;
    private WaitForSeconds _delaySecond;
    private WaitForSeconds _waitingAfterCunstruction;

    private List<Cube> _allCubeList;
    private List<PixelPoint> _pixelPoints;
    private List<string> _cubeColors;

    private int _currentLevel;
    private int _buildCubes = 0;
    private int _waitAfterConstruction = 2;
    private int _maxCubesCount;
    private int _second = 1;

    public float BuildCubes => _buildCubes;
    public int MaxCubesCount => _maxCubesCount;

    private void Awake()
    {
        _delaySpawn = new WaitForSeconds(_delaySpawnCubes);
        _waitingAfterCunstruction = new WaitForSeconds(_waitAfterConstruction);
        _delaySecond = new WaitForSeconds(_second);
        _effectsSpawner.Initialize();

        _currentLevel = PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey);
        _maxCubesCount = _levels[_currentLevel-1].CountCubes;
        _parentSubstrate = Instantiate(_levels[_currentLevel-1].PixelArtPrefab).transform;
        LoadCubeData();

        _pixelPoints = _parentSubstrate.GetComponentsInChildren<PixelPoint>().ToList();
        StartCoroutine(BuildPixelArt());
    }

    private void OnDestroy() => transform.DOKill();

    private IEnumerator BuildPixelArt()
    {
        yield return _delaySecond;
        StartCoroutine(_effectsSpawner.SpawnEffect(_audioEffects));

        foreach (var cubeColor in _cubeColors)
        {
            foreach (var point in _pixelPoints)
            {
                if (cubeColor == point.GetColor() && point.IsFilled == false)
                {
                    _cubesSpawner.Spawn(point, _parentSubstrate);
                    _audioEffects.PlaySoundCubeBuilding();
                    _buildCubes++;
                    point.Fill();
                    UpdateSliderAction?.Invoke(_buildCubes);
                    yield return _delaySpawn;
                    break;
                }
            }
        }

        _effectsSpawner.PixelArtBuilt();
        yield return _waitingAfterCunstruction;
        UpdateResults?.Invoke(_buildCubes, _maxCubesCount, _currentLevel);
        _allCubeList = _parentSubstrate.GetComponentsInChildren<Cube>().ToList();

        foreach (Cube cube in _allCubeList)
            cube.Rigidbody.isKinematic = false;

        if (_buildCubes > _maxCubesCount / DevisorHalf)
            SaveComplatedLevel();
    }

    private void SaveComplatedLevel()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.LevelProgressKey + _currentLevel, ValueLevelCompletion);
        PlayerPrefs.Save();
    }

    private void LoadCubeData()
    {
        string json = PlayerPrefs.GetString(PlayerPrefsKeys.CubeDataKey);
        CubeListDTO cubeDTO = JsonUtility.FromJson<CubeListDTO>(json);
        _cubeColors = cubeDTO.Colors;
    }
}
