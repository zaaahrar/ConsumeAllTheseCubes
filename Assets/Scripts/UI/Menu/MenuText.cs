using TMPro;
using UnityEngine;
using DG.Tweening;

public class MenuText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _textScale;

    private void Start() => AniamteText();

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void AniamteText()
    {
        _text.transform.DOScale(_textScale, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
