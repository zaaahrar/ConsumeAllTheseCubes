using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ImprovementsValue _improvementsConfig;
    [SerializeField] private Transform _pointSpawnText;
    [SerializeField] private bool _isCollected = false;
    [SerializeField] private Color _color;
    [SerializeField] private int _reward;

    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (PlayerPrefs.HasKey(PlayerPrefsKeys.MoneyPerCubeLevelKey))
            _reward += PlayerPrefs.GetInt(PlayerPrefsKeys.MoneyPerCubeLevelKey) * _improvementsConfig.GoldPerCubeValue;
    }

    private enum Color
    {
        Red,
        DarkRed,
        Yellow,
        White,
        Gray,
        Black,
        Turquoise
    };

    public Transform PointSpawnText => _pointSpawnText;
    public int Reward => _reward;
    public bool IsCollected => _isCollected;

    public string GetColor()
    {
        return _color.ToString();
    }

    public void CollectCube() => _isCollected = true;

    public void GiveReward(MoneyHandler moneyHandler) => moneyHandler.AddMoney(_reward);
}
