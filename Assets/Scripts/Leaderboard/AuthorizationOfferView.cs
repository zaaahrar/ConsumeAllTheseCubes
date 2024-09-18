using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationOfferView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _authorizeButton;
    [SerializeField] private GameObject _panel;

    private Action _onAuthorizeSuccess;
    private Action _onAuthorizeError;

    private void Awake()
    {
        _closeButton.onClick.AddListener(Hide);
        _authorizeButton.onClick.AddListener(OnAuthorizeButtonClick);
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(Hide);
        _authorizeButton.onClick.RemoveListener(OnAuthorizeButtonClick);
    }

    public void Show(Action onAuthorizeSuccess, Action onAuthorizeError)
    {
        _onAuthorizeSuccess = onAuthorizeSuccess;
        _onAuthorizeError = onAuthorizeError;

        _panel.SetActive(true);
    }

    private void Hide() => _panel.SetActive(false);

    private void OnAuthorizeButtonClick()
    {
        void OnAuthorizeSuccess() => _onAuthorizeSuccess?.Invoke();
        void OnAuthorizeError(string error) => _onAuthorizeError?.Invoke();

        Agava.YandexGames.PlayerAccount.Authorize(OnAuthorizeSuccess, OnAuthorizeError);
        Hide();
    }
}
