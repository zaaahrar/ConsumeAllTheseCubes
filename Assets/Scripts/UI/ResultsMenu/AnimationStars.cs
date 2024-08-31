using UnityEngine;
using DG.Tweening;

public class AnimationStars : MonoBehaviour
{
    [SerializeField] private float _durationAnimate;

    private Vector3 _finishScale = new Vector3(0.95f, 1, 1);

    private void OnEnable() => transform.DOScale(_finishScale, _durationAnimate);
}
