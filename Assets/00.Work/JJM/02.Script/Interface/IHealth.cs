using UnityEngine;

public interface IHealth
{
    public int MaxHealth { get; }
    public int CurrentHealth { get; }

    public void GetDamage(int damage);
    public void GetHeal(int heal);
    public void Die();
}
