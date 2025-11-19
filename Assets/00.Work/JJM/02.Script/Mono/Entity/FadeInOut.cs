using DG.Tweening;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private float _inTime = 0.5f;
    [SerializeField] private float _time = 3f;
    [SerializeField] private float _outTime = 0.5f;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();

        Sequence seq = DOTween.Sequence();

        seq.Append(_renderer.DOFade(0.3f, _inTime));
        seq.AppendInterval(_time);
        seq.Append(_renderer.DOFade(0f, _outTime));
    }
}
