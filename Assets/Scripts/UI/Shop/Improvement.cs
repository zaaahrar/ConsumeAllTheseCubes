using UnityEngine;

public abstract class Improvement : MonoBehaviour
{
    [SerializeField] private int[] _prices;
    [SerializeField] private int _maxLevel;

    private int _level = 1;

    public int Level => _level;
    public int[] Prices => _prices;
    public int MaxLevel => _maxLevel;

    public void GetLevel(int level)
    {
        _level = level;
        
        if(level == 0) 
            _level = 1;
    }

    public void AddLevel() => _level++;

    public int GetCost()
    {
        return _prices[_level - 1];
    }
}
