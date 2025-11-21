using UnityEngine;
using DG.Tweening;

public class HitEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticle;
    [SerializeField] private ParticleSystem _hitParticleFlyaway;
    private HealthSystem _healthSystem;
    private SpriteRenderer _renderer;
    [SerializeField] private Animator _anim;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _renderer = transform.root.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _healthSystem.OnGetDamage += HitParticlePlay;
    }

    private void OnDisable()
    {
        _healthSystem.OnGetDamage -= HitParticlePlay;
    }

    private void OnDestroy()
    {
        _healthSystem.OnGetDamage -= HitParticlePlay;
    }

    private void Update()
    {
        
    }

    private void HitParticlePlay(int num, Transform tran)
    {
        _anim.Play("Hit", 0, 0f);
        _anim.transform.rotation = Quaternion.Euler(0, 0, 
            InGameManager.Instance.TargetLook(transform, InGameManager.Instance.Player.transform) + 60f);
        _renderer.DOKill();
        _renderer.color = Color.black;

        _hitParticle.Play();
        _hitParticle.Play();

        _renderer.color = Color.white;
        _renderer.DOColor(Color.black, 0.5f);

        Vector2 rotationVector = -(tran.position - transform.position).normalized * 12.5f;


        var time = _hitParticleFlyaway.velocityOverLifetime; 
        time.x = rotationVector.x;
        time.y = rotationVector.y;
        _hitParticleFlyaway.Play();
    }
}
