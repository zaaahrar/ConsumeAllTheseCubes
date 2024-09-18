using UnityEngine;

public class FunnelMover : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";
    private const string AxisVertical = "Vertical";

    [SerializeField] private ImprovementsValue _improvementsConfig;
    [SerializeField] private float _speed;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.SpeedLevelKey))
            _speed += PlayerPrefs.GetInt(PlayerPrefsKeys.SpeedLevelKey) * _improvementsConfig.SpeedValue;
    }

    public void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis(AxisHorizontal);
        float moveVertical = Input.GetAxis(AxisVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(_speed * Time.fixedDeltaTime * movement);
    }
}
