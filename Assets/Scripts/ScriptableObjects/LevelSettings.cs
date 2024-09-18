using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private int _time;
    [SerializeField] private int _countCubes;
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _pixelArtPrefab;

    public GameObject LevelPrefab => _levelPrefab;
    public int Time => _time;
    public int CountCubes => _countCubes; 
    public GameObject PixelArtPrefab => _pixelArtPrefab;
}
