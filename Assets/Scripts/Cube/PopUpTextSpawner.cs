using UnityEngine;

public class PopUpTextSpawner : MonoBehaviour
{
    [SerializeField] private PopUpTextMoney _prefabText;
    [SerializeField] private Transform _parentCanvas;

    public void Spawn(Transform spawnPoint, int reward)
    {
        PopUpTextMoney text = Instantiate(_prefabText, spawnPoint.position, Quaternion.identity, _parentCanvas);
        text.UpdateText(reward);
    }
}
