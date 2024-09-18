using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenuView : MonoBehaviour
{
    [SerializeField] private GameObject _panelLevelSelect;
    [SerializeField] private UIAudioFeedback _audio;

    [Header("Buttons")]
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

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

    public void Open()
    {
        _audio.PlaySoundClick();
        _panelLevelSelect.SetActive(true);
    }

    public void Close()
    {
        _audio.PlaySoundClick();
        _panelLevelSelect.SetActive(false);
    }
}
