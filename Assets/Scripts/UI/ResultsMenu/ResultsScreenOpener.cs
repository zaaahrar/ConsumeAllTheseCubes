using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreenOpener : MonoBehaviour
{
    [SerializeField] private PixelArtBuilder _pixelArtBuilder;
    [SerializeField] private UIAudioFeedback _audioFeedback;
    [SerializeField] private ResultsDisplay _resultsDisplay;
    [SerializeField] private Slider _pixelArtBuildSlider;
    [SerializeField] private float _durationAnimate;

    private float _finishPositionY = -125   ;

    private void OnEnable() => _pixelArtBuilder.OpenFinishMenu += Open;

    private void OnDisable() => _pixelArtBuilder.OpenFinishMenu -= Open;

    private void Open()
    {
        _audioFeedback.PlaySoundResultsPanelActive();
        _resultsDisplay.gameObject.SetActive(true);
        _pixelArtBuildSlider.gameObject.SetActive(false);
        _resultsDisplay.transform.DOLocalMoveY(_finishPositionY, _durationAnimate);
    }
}
