using UnityEngine;

public class UIElementDisplay : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelLevelSelect;
    [SerializeField] private GameObject _panelMenu;

    [SerializeField] private UIAudioFeedback _audio;

    public void OpenPanelSettings()
    {
        _panelSettings.SetActive(true);
        _panelMenu.SetActive(false);
        _audio.PlaySoundClick();
    }

    public void OpenPanelLevelSelect()
    {
        _panelLevelSelect.SetActive(true);
        _panelMenu.SetActive(false);
        _audio.PlaySoundClick();
    }

    public void OpenMenu()
    {
        _panelMenu.SetActive(true);
        _panelLevelSelect.SetActive(false);
        _panelSettings.SetActive(false);
        _audio.PlaySoundClick();
    }

}
