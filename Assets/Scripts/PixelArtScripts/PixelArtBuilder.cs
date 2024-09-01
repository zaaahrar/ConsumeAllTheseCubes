using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using System;

public class PixelArtBuilder : MonoBehaviour
{
    private const string CubeDataKey = "CubeData";
    private const string LevelDataKey = "LevelData";
    private const string LevelKey = "Level";
    private const int Second = 1;
    private const int DevisorHalf = 2;
    private const int ValueTrue = 1;

    [SerializeField] private List<string> _cubesColor;
    [SerializeField] private List<PixelPoint> _pixelPointsList;
    [SerializeField] private GameObject _boomEffect;
    [SerializeField] private Transform _parentPoints;
    [SerializeField] private Transform _parentSubstrate;
    [SerializeField] private float _delaySpawnNumber;
    [SerializeField] private float _cubeFlightTime;
    [SerializeField] private float _delayBoomEffect;
    [SerializeField] private AudioEffects _audioEffects;

    [Header("PixelArtConfig")]
    [SerializeField] private List<Cube> _pixelArtEdging;
    [SerializeField] private List<Vector3> _positionEdging;
    [SerializeField] private List<Vector3> _positionPoint;
    [SerializeField] private List<string> _colorPixels;

    [Header("SpawnPointCubes")]
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private Transform _minPosition;

    private WaitForSeconds _delaySpawn;
    private WaitForSeconds _second;
    private WaitForSeconds _delayEffect;
    private List<Cube> _allCubeList;
    private bool _pixelArtBuilt = false;
    private float _buildCubes = 0;
    private int _maxCubesCount;

    public event Action<float> UpdateSliderAction;
    public event Action OpenFinishMenu;
    public event Action<float, float> UpdateResults;

    public float BuildCubes => _buildCubes;
    public int MaxCubesCount => _maxCubesCount;

    private void Awake()
    {
        _delaySpawn = new WaitForSeconds(_delaySpawnNumber);
        _delayEffect = new WaitForSeconds(_delayBoomEffect);
        _second = new WaitForSeconds(Second);
        GetData();
        LoadCubeData();
    }

    private void Start()
    {
        _pixelPointsList = _parentPoints.GetComponentsInChildren<PixelPoint>().ToList();

        StartCoroutine(BuildPixelArt());
        StartCoroutine(SpawnEffect());
    }

    private void OnDestroy() => transform.DOKill();

    [ContextMenu("WritePixelArtConfig")]
    public void WriteCubeConfig()
    {
        foreach (Cube cube in _pixelArtEdging)
        {
            _positionEdging.Add(new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z));
        }

        foreach (var pixelPoint in _pixelPointsList)
        {
            _positionPoint.Add(pixelPoint.transform.position);
            _colorPixels.Add(pixelPoint.GetColor());
        }

        PixelArtConfig pixelArt = new PixelArtConfig();
        pixelArt.SpawnPointsPixels = _positionPoint;
        pixelArt.SpawnPointsEdging = _positionEdging;
        pixelArt.ColorPixels = _colorPixels;
        string json = JsonUtility.ToJson(pixelArt);
        Debug.Log(json);

        PlayerPrefs.SetString("PixelArtConfig", json);
    }

    private IEnumerator BuildPixelArt()
    {
        yield return _second;

        StartCoroutine(SpawnEffect());

        foreach (var cubeColor in _cubesColor)
        {
            foreach (var point in _pixelPointsList)
            {
                if (cubeColor == point.GetColor() && point.IsFilled == false)
                {
                    SpawnCube(point);
                    _audioEffects.PlaySoundCubeBuilding();
                    _buildCubes++;
                    point.Fill();
                    yield return _delaySpawn;
                    UpdateSliderAction?.Invoke(_buildCubes);
                    break;
                }
            }
        }

        _pixelArtBuilt = true;
        yield return _second;

        OpenFinishMenu?.Invoke();
        UpdateResults?.Invoke(_buildCubes, _maxCubesCount);

        _allCubeList = _parentSubstrate.GetComponentsInChildren<Cube>().ToList();

        foreach (Cube cube in _allCubeList)
            cube.Rigidbody.isKinematic = false;

        if (_buildCubes > _maxCubesCount / DevisorHalf)
            SaveComplatedLevel();
    }

    private IEnumerator SpawnEffect()
    {
        yield return _second;

        while (_pixelArtBuilt == false)
        {
            Instantiate(_boomEffect, GetRandomPosition(), Quaternion.identity);
            _audioEffects.PlaySoundKnock();
            yield return _delayEffect;
        }
    }

    private void GetData()
    {
        string json = PlayerPrefs.GetString(LevelDataKey);
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        _maxCubesCount = levelConfig.CountCubes;
    }

    private void SpawnCube(PixelPoint pixelPoint)
    {
        Cube cube = Instantiate(pixelPoint.CubePrefab, GetRandomPosition(), Quaternion.identity, _parentSubstrate);
        cube.Rigidbody.isKinematic = true;
        cube.transform.DOMove(pixelPoint.transform.position, _cubeFlightTime).SetEase(Ease.OutFlash);
    }

    private Vector3 GetRandomPosition()
    {
        float randomPositionX = UnityEngine.Random.Range(_minPosition.position.x, _maxPosition.position.x);
        float randomPositionY = UnityEngine.Random.Range(_minPosition.position.y, _maxPosition.position.y);
        float randomPositionZ = UnityEngine.Random.Range(_minPosition.position.z, _maxPosition.position.z);

        return new Vector3(randomPositionX, randomPositionY, randomPositionZ);
    }

    private void SaveComplatedLevel()
    {
        string json = PlayerPrefs.GetString(LevelDataKey);
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        PlayerPrefs.SetInt(LevelKey + levelConfig.LevelNumber, ValueTrue);
    }

    private void LoadCubeData()
    {
        string json = PlayerPrefs.GetString(CubeDataKey);
        CubeListDTO cubeDTO = JsonUtility.FromJson<CubeListDTO>(json);
        _cubesColor = cubeDTO.Colors;
    }
}
