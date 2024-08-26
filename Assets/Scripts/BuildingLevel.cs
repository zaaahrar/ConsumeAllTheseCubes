using System.Collections.Generic;
using UnityEngine;

public class BuildingLevel : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubePrefabs;
    [SerializeField] private Transform _parentCubes;
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private Timer _timer;

    private int _countCubes;
    private List<Vector3> _spawnPoints;
    private List<string> _colors;
    public List<Vector3> SpawnPoints;
    public List<string> Colors;

    private void Awake()
    {
        string json = PlayerPrefs.GetString("LevelData");
        LevelConfigTemplate levelConfig = JsonUtility.FromJson<LevelConfigTemplate>(json);
        _countCubes = levelConfig.CountCubes;
        _spawnPoints = levelConfig.SpawnPoints;
        _colors = levelConfig.Colors;
        Debug.Log(json);
        _timer.ChangeTime(levelConfig.Time);

        for (int i = 0; i < _colors.Count; i++)
        {
            SpawnCube(_colors[i], _spawnPoints[i]);
        }
    }

    [ContextMenu("WriteCubeConfig")]
    public void WriteCubeConfig()
    {
        foreach (Cube cube in _cubes)
        {
            SpawnPoints.Add(cube.transform.position);
            Colors.Add(cube.GetColor());
        }

        SpawnCubeConfig cubeConfig = new SpawnCubeConfig();
        cubeConfig.Position = SpawnPoints;
        cubeConfig.Color = Colors;
        string json = JsonUtility.ToJson(cubeConfig);

        PlayerPrefs.SetString("CubeConfig", json);
    }

    private void SpawnCube(string color, Vector3 postion)
    {
        foreach(Cube cube in _cubePrefabs)
        {
            if(cube.GetColor() == color)
                Instantiate(cube, postion, Quaternion.identity, _parentCubes);
        }
    }
}
