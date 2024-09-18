using UnityEngine;

[CreateAssetMenu(fileName = "ImprovementConfig", menuName = "ScriptableObjects/ImprovementConfig")]
public class ImprovementsValue : ScriptableObject
{
    [SerializeField] private float _speedValue;
    [SerializeField] private int _goldPerCubeValue;
    [SerializeField] private int _timeValue;

    public float SpeedValue => _speedValue;
    public int GoldPerCubeValue => _goldPerCubeValue;
    public int TimeValue => _timeValue;
}
