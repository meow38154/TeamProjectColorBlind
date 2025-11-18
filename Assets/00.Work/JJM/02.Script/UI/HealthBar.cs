
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private HealthSystem _healthSystem;
    [Header("ObjectTransform")]
    [SerializeField] private Transform _healthBar;
    [Header("Prefabs")]
    [SerializeField] private GameObject _heart;
    private void Awake()
    {
        for (int i = 0; i < _healthSystem.MaxHealth; i++)
        {
            Instantiate(_heart, _healthBar);
        }
    }

    private void OnEnable()
    {
        _healthSystem.OnGetDamage += HeartUpdate;
        _healthSystem.OnDie += Died;
    }

    private void OnDisable()
    {
        _healthSystem.OnGetDamage -= HeartUpdate;
        _healthSystem.OnDie -= Died;
    }

    private void HeartUpdate(int a, Transform t)
    {
        for (int i = 0; i < _healthSystem.MaxHealth; i++)
        {
            if (i >= _healthSystem.CurrentHealth)
            {
                _healthBar.GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                _healthBar.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    private void Died()
    {
        _healthBar.GetChild(_healthSystem.MaxHealth).GetChild(1).gameObject.SetActive(false);
    }
}
