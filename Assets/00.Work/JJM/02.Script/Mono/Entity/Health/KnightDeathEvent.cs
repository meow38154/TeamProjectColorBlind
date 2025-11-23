using DG.Tweening;
using UnityEngine;

public class KnightDeathEvent : MonoBehaviour
{
    private GameObject _parents;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _parents = transform.root.gameObject;
    }

    private void OnEnable()
    {
        _healthSystem.OnDie += Play;
    }

    private void OnDisable()
    {
        _healthSystem.OnDie -= Play;
    }

    private void OnDestroy()
    {
        _healthSystem.OnDie -= Play;
    }

    private void Play()
    {
        Sequence seq = DOTween.Sequence();
        SpriteRenderer renderer = _parents.GetComponentInChildren<SpriteRenderer>();
        seq.AppendCallback(() =>
        {
            _parents.GetComponentInChildren<LineRenderer>().enabled = false;
        });
            seq.Append(renderer.DOColor(Color.white, 2f));
        seq.AppendInterval(1.5f);

        seq.Append(renderer.DOFade(0, 1));

        
        seq.AppendCallback(() =>
        {
            SoundManager.Instance.PlaySound(14, 1f, 0.5f);

            Destroy(_parents.gameObject);
        });
    }
}
