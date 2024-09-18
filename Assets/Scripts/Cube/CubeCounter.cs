using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CubeCounter : MonoBehaviour
{
    [SerializeField] private float _collectedCubes = 0;
    [SerializeField] private IncreasingFunnel _increasingFunnel;
    [SerializeField] private Transform _parentCubes;

    public event Action<float> SliderUpdateEvent;

    private Cube[] _allCube;
    private int _totalCubesCount = 0;
    private int _totalCubesCollected;

    public int TotalCubesCount => _totalCubesCount;

    private void Start()
    {
        _allCube = _parentCubes.GetComponentsInChildren<Cube>();
        _totalCubesCount = _allCube.Length;
    }

    public float CollectedCubes => _collectedCubes;

    public void AddCube()
    {
        _collectedCubes++;
        _increasingFunnel.CollectCube();
        SliderUpdateEvent?.Invoke(_collectedCubes);

        _totalCubesCollected = Agava.YandexGames.Utility.PlayerPrefs.GetInt(LeaderboardConstants.SCORE_PREFS_KEY, 0) + 1;

#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(LeaderboardConstants.SCORE_PREFS_KEY, _totalCubesCollected);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        Agava.YandexGames.Leaderboard.SetScore(LeaderboardConstants.LEADERBOARD_NAME, _totalCubesCollected);
#endif
    }
}
