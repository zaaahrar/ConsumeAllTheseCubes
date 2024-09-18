using TMPro;
using UnityEngine;
using DG.Tweening;

public class NameGameAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _textScale;

    private void Start() => AniamteText();

    private void AniamteText() => _text.transform.DOScale(_textScale, _duration).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
}
