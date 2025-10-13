using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour, IHealth
{
    public int MaxHealth { get => _maxHealth; }
    public int CurrentHealth { get => _currentHealth; }

    public Action OnGetDamge;
    public Action OnHealHealth;
    public Action OnDie;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        if (_currentHealth < 0)
        {
            OnGetDamge?.Invoke();
        }
    }

    public void GetHeal(int heal)
    {
        OnHealHealth?.Invoke();
        _currentHealth += heal;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void Die()
    {
        OnDie?.Invoke();
        Debug.Log($"{gameObject} is die");
    }
}
