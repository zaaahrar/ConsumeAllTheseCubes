using UnityEngine;

public class FunnelTriggerChecker : MonoBehaviour
{
    [SerializeField] private PopUpTextSpawner _popUpTextSpawner;
    [SerializeField] private AudioEffects _audioEffects;
    [SerializeField] private Funnel _funnel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube) && other.TryGetComponent(out CubeFall cubeFall))
        {
            StartCoroutine(cubeFall.Fall(_funnel));
            _popUpTextSpawner.Spawn(cube.PointSpawnText, cube.Reward);
            _audioEffects.PlaySoundCubeCollect();
        }
    }
}
