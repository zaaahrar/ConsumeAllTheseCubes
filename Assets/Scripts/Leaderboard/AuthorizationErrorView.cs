using UnityEngine;
using UnityEngine.UI;

public class AuthorizationErrorView : MonoBehaviour
{
    [SerializeField] private Button _confirmButton;
    [SerializeField] private GameObject _panel;

    private void Awake() => _confirmButton.onClick.AddListener(Hide);
    private void OnDestroy() => _confirmButton.onClick.RemoveListener(Hide);

    public void Show() => _panel.SetActive(true);
    private void Hide() => _panel.SetActive(false);
}
