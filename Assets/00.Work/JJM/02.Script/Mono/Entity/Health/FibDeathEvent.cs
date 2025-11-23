using DG.Tweening;
using UnityEngine;

public class FibDeathEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private ParticleSystem _particle2;
    private TargetFollow _targetFollow;
    private GameObject _parents;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _parents = transform.root.gameObject;
        _targetFollow = _parents.GetComponentInChildren<TargetFollow>();
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
        _targetFollow.Move = false;
        Sequence seq = DOTween.Sequence();
        SpriteRenderer renderer = _parents.GetComponentInChildren<SpriteRenderer>();
        seq.Append(renderer.DOColor(Color.white, 1f));
        seq.AppendCallback(()=>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);

        });
        seq.AppendInterval(2f);
        seq.AppendCallback(() =>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);


        });
        seq.AppendInterval(1.5f);
        seq.AppendCallback(() =>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);


        });
        seq.AppendInterval(0.8f);
        seq.AppendCallback(() =>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);


        });
        seq.AppendInterval(0.4f);
        seq.AppendCallback(() =>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);


        });
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() =>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);


        });
        seq.AppendInterval(0.1f);
        seq.AppendCallback(() =>
        {
            _particle.Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1.3f, 0.7f);
            SoundManager.Instance.PlaySound(14, 1f);


        });

        seq.Append(_parents.transform.DOScale(Vector3.zero, 2f).SetEase(Ease.InBack));

        seq.AppendCallback(() =>
        {
            SoundManager.Instance.PlaySound(15, 1.5f, 1f);

            GameObject p = Instantiate(_particle2.gameObject);
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            p.transform.position = _parents.transform.position;
            p.GetComponent<ParticleSystem>().Play();
            Destroy(_parents.gameObject); });
    }
}
