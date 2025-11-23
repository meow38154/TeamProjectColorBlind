using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SlimeDeathEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
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
        SpriteRenderer spriteRenderer = _parents.GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.DOColor(Color.red, 4);
        seq.Append(spriteRenderer.transform.DOScale(spriteRenderer.transform.localScale * 1.5f, 4));
        seq.AppendCallback(() =>
        {
             GameObject a = Instantiate(_particleSystem.gameObject);
            a.transform.position = _parents.transform.position;

            a.GetComponent<ParticleSystem>().Play();
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
            SoundManager.Instance.PlaySound(15, 1f, 1.5f);

            Destroy(_parents);
        });

        
    }

}

