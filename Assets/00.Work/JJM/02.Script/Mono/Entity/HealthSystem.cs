using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _maxHealth; 
    [SerializeField] private int _currentHealth;

    public Action OnGetDamge; //대미지 입었을 때 호출될 액션
    public Action OnHealHealth; //체력 회복을 했을 때 호출될 액션
    public Action OnDie; //죽었을 때 호출될 액션


    private void Awake()
    {
        _currentHealth = _maxHealth; //현재 체력을 최대체력으로 설정
    }

    public void GetDamage(int damage)
    {
        _currentHealth -= damage; //현재 체력에 받은 대미지 만큼을 깜
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //현재 체력을 0~_maxHealth 사이로 바꿔둚(체력이 -로 가지 않게)
        if (_currentHealth > 0) //설정 이후 체력이 0 초과일 때
        {
            OnGetDamge?.Invoke(); //대미지를 입었을 때 사용되는 액션 호출 (null이면 호출 안함)
        }

        else //설정 이후 체력이 0 이하일 때
        {
            Die(); //죽었을 때 사용되는 메서드 호출
        }
    }

    public void GetHeal(int heal)
    {
        OnHealHealth?.Invoke(); //체력을 회복했을 때 사용되는 액션 호출 (null이면 호출 안함)
        _currentHealth += heal; //받은 힐량 만큼 체력을 회복
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //현재 체력을 0~_maxHealth 사이로 바꿔둚(체력이 최대체력을 초과하지 않게)
    }

    public void Die()
    {
        OnDie?.Invoke(); //죽었을 때 사용되는 액션 호출 (null이면 호출 안함)
        Debug.Log($"{gameObject} is die");
    }
}
