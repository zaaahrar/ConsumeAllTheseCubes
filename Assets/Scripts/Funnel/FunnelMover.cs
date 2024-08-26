using UnityEngine;

public class FunnelMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(_speed * Time.fixedDeltaTime * movement);
    }
}
