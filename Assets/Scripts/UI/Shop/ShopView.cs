using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] private GameObject _panelShop;
    [SerializeField] private TMP_Text _currentMoney;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
    }

    public void UpdateMoney(int money) => _currentMoney.text = money.ToString();

    public void Open()
    {
        _audioFeedback.PlaySoundClick();
        _panelShop.gameObject.SetActive(true);
    }

    public void Close()
    {
        _audioFeedback.PlaySoundClick();
        _panelShop.gameObject.SetActive(false);
    }
}
