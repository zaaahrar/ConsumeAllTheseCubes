using System;
using UnityEngine;

public class CubeCounter : MonoBehaviour
{
    [SerializeField] private float _collectedCubes = 0;
    [SerializeField] private IncreasingFunnel _increasingFunnel;
    [SerializeField] private Transform _parentCubes;

    public event Action<float> SliderUpdateEvent;

    private Cube[] _allCube;
    private int _totalCubesCount;

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
    }
}
