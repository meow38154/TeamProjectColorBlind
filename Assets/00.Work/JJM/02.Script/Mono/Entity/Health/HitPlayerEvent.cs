using UnityEngine;

public class HitPlayerEvent : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _renderer = transform.root.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _healthSystem.OnGetDamage += PlayerEvent;
    }

    private void OnDisable()
    {
        _healthSystem.OnGetDamage -= PlayerEvent;
    }

    private void OnDestroy()
    {
        _healthSystem.OnGetDamage -= PlayerEvent;
    }

    public void PlayerEvent(int a, Transform t)
    {
        InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
    }
}
