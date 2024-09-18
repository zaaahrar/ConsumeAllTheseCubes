using System.Collections;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Cube))]
public class CubeFall : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _rotationDuration = 0.8f;

    private Collider _collider;
    private Cube _cube;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _cube = GetComponent<Cube>();
    }

    public IEnumerator Fall(Funnel funnel)
    {
        Vector3 directionToCenter = funnel.Center.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(-directionToCenter);

        _collider.isTrigger = true;

        transform.position = Vector3.MoveTowards(transform.position, funnel.Center.position, _speed * Time.deltaTime);
        transform.DORotateQuaternion(rotation, _rotationDuration).SetLink(gameObject, LinkBehaviour.KillOnDisable);

        while (_cube.IsCollected == false)
        {
            yield return null;
        }

        _cube.GiveReward(funnel.MoneyHandler);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
