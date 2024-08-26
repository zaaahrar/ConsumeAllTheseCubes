using UnityEngine;

public class PixelPoint : MonoBehaviour
{
    [SerializeField] private Colors _color;
    [SerializeField] private Cube _cubePrefab;

    private bool _isFilled = false;

    public bool IsFilled => _isFilled;
    public Cube CubePrefab => _cubePrefab;

    private enum Colors
    {
        Red,
        DarkRed,
        White,
        Black,
        Yellow,
        Gray,
        Turquoise
    };

    public string GetColor()
    {
        return _color.ToString();
    }

    public void Fill() => _isFilled = true;
}
