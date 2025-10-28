using UnityEngine;
using DG.Tweening;

public class HitParticleEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticle;
    [SerializeField] private ParticleSystem _hitParticleFlyaway;
    private HealthSystem _healthSystem;
    private SpriteRenderer renderer;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        renderer = transform.root.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _healthSystem.OnGetDamge += HitParticlePlay;
    }

    private void OnDisable()
    {
        _healthSystem.OnGetDamge -= HitParticlePlay;
    }

    private void OnDestroy()
    {
        _healthSystem.OnGetDamge -= HitParticlePlay;
    }

    private void Update()
    {
        
    }

    private void HitParticlePlay(int num, Transform tran)
    {
        renderer.DOKill();
        renderer.color = Color.black;

        _hitParticle.Play();
        _hitParticle.Play();

        renderer.color = Color.white;
        renderer.DOColor(Color.black, 0.5f);

        Vector2 rotationVector = -(tran.position - transform.position).normalized * 12.5f;


        var time = _hitParticleFlyaway.velocityOverLifetime; 
        time.x = rotationVector.x;
        time.y = rotationVector.y;
        _hitParticleFlyaway.Play();
    }
}
