using System.Collections;
using UnityEngine;

public class EffectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private float _delay;
    private WaitForSeconds _delayEffect;
    private WaitForSeconds _delaySecond;
    private int _second = 1;
    private bool _isPixelArtBuilt = false;
    private Vector3 _maxPosition = new Vector3(0, 5.5f, -5);
    private Vector3 _minPosition = new Vector3(-3, 4.5f, -4);

    public void Initialize()
    {
        _delayEffect = new WaitForSeconds(_delay);
        _delaySecond = new WaitForSeconds(_second);
    }

    public IEnumerator SpawnEffect(AudioEffects audioEffects)
    {
        yield return _second;

        while (_isPixelArtBuilt == false)
        {
            Instantiate(_effect, GetRandomPosition(), Quaternion.identity);
            audioEffects.PlaySoundKnock();
            yield return _delayEffect;
        }
    }

    public void PixelArtBuilt() => _isPixelArtBuilt = true;

    private Vector3 GetRandomPosition()
    {
        float randomPositionX = Random.Range(_minPosition.x, _maxPosition.x);
        float randomPositionY = Random.Range(_minPosition.y, _maxPosition.y);
        float randomPositionZ = Random.Range(_minPosition.z, _maxPosition.z);

        return new Vector3(randomPositionX, randomPositionY, randomPositionZ);
    }
}
