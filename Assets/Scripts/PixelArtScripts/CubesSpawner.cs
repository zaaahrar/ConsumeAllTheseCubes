using DG.Tweening;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private float _cubeFlightTime;

    private Vector3 _maxPosition = new Vector3(0, 5.5f, -5);
    private Vector3 _minPosition = new Vector3(-3, 4.5f, -4);

    public void Spawn(PixelPoint pixelPoint, Transform _parentSubstrate)
    {
        Cube cube = Instantiate(pixelPoint.CubePrefab, GetRandomPosition(), Quaternion.identity, _parentSubstrate);
        cube.Rigidbody.isKinematic = true;
        cube.transform.DOMove(pixelPoint.transform.position, _cubeFlightTime).SetEase(Ease.OutFlash).SetLink(cube.gameObject, LinkBehaviour.KillOnDestroy);
    }

    private Vector3 GetRandomPosition()
    {
        float randomPositionX = Random.Range(_minPosition.x, _maxPosition.x);
        float randomPositionY = Random.Range(_minPosition.y, _maxPosition.y);
        float randomPositionZ = Random.Range(_minPosition.z, _maxPosition.z);

        return new Vector3(randomPositionX, randomPositionY, randomPositionZ);
    }
}
