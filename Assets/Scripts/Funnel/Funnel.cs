using UnityEngine;

public class Funnel : MonoBehaviour
{
    [SerializeField] private MoneyHandler _moneyHandler;
    [SerializeField] private Transform _center;

    public MoneyHandler MoneyHandler => _moneyHandler;
    public Transform Center => _center;
}
