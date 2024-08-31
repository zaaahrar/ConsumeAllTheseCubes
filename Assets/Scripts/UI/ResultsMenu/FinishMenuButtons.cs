using UnityEngine;

public class FinishMenuButtons : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private UIAudioFeedback _audioFeedback;

    public void ResetLevel()
    {
        _audioFeedback.PlaySoundClick();
        _sceneChanger.LoadGameScene();
    }

    public void ExitMenu()
    {
        _audioFeedback.PlaySoundClick();
        _sceneChanger.LoadMenuScene();
    }
}
