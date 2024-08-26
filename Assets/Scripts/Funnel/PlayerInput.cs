using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode KeyForward = KeyCode.W;
    private const KeyCode KeyLeft = KeyCode.A;
    private const KeyCode KeyRight = KeyCode.D;
    private const KeyCode KeyBack = KeyCode.S;

    [SerializeField] private FunnelMover _funnelMover;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyForward))
            _funnelMover.MovementLogic();
        else if (Input.GetKey(KeyLeft))
            _funnelMover.MovementLogic();
        else if (Input.GetKey(KeyRight))
            _funnelMover.MovementLogic();
        else if (Input.GetKey(KeyBack))
            _funnelMover.MovementLogic();
    }
}
