using UnityEngine;

public class HitParticleEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticle;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
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

    private void HitParticlePlay()
    {
        _hitParticle.Play();
    }
}
